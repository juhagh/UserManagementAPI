using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public User Add(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }

    public User? Update(int id, User updated)
    {
        if (updated == null)
            throw new ArgumentNullException(nameof(updated));

        var existing = GetById(id);
        if (existing == null) return null;

        existing.Name = updated.Name;
        existing.Email = updated.Email;

        return existing;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user == null) return false;

        _users.Remove(user);
        return true;
    }
}