using UserManagementAPI.Repositories;
using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register in-memory repository
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();

var app = builder.Build();

// 1. Error handling (first)
app.UseMiddleware<ErrorHandlingMiddleware>();

// 2. Authentication
app.UseMiddleware<AuthenticationMiddleware>();

// 3. Logging
app.UseMiddleware<LoggingMiddleware>();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();