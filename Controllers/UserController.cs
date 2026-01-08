using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UserController(IUserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
        => Ok(_repo.GetAll());

    [HttpGet("{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = _repo.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public ActionResult<User> Create(User user)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _repo.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<User> Update(int id, User user)
    {
        var updated = _repo.Update(id, user);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _repo.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}