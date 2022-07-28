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
        return _context.Users.ToList();
    }
    public async Task<User> GetUserById(int userID)
    {
        User? foundUser = await _context.Users.FirstOrDefault(user => user.UserId == userID);
        if(foundUser != null) return foundUser;

        throw new RecordNotFoundException("could not find the user with such id");
    }
    public User GetUserByUsername(string username)
    {

    }
    public bool CreateUser(User user)
    {

    }
    public bool UpdateUser(User user)
    {
        
    }

}