using Galacticos.Application.Persistence.Contracts;
using Galacticos.Domain.Entities;
using Galacticos.Infrastructure.Data;

namespace Galacticos.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _context.users.Add(user);
        if(_context.SaveChanges() == 0)
            throw new Exception("User not added");
    }

    public User? GetUserByIdentifier(string identifier)
    {
        return _context.users.FirstOrDefault(u => u.Email == identifier || u.UserName == identifier);
    }

    public User? GetUserByEmail(string email)
    {
        return _context.users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetUserById(Guid id)
    {
        return _context.users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetUserByUserName(string userName)
    {
        return _context.users.FirstOrDefault(u => u.UserName == userName);
    }
}