using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class UserRepository : IUserDAO
{
    private readonly StonksDbContext _context;
    public UserRepository(StonksDbContext context)
    {
        _context = context;
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToListAsync();
    }
    public User GetUserById(int userID)
    {
        User? foundUser = _context.Users.FirstOrDefaultAsync(user => user.UserId == userID);
        if(foundUser != null) return foundUser;
        throw new RecordNotFoundException("could not find the user with such id");
    }
    public User GetUserByEmail(string email)
    {
        User? foundUser = _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        if(foundUser != null) return foundUser;
        throw new RecordNotFoundException("could not find the user with such email");
    }
    public bool CreateUser(User user)
    {
        _context.Add(user);
        _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
    public bool UpdateUser(User user)
    {
        _context.Update(user);
        _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }

}
