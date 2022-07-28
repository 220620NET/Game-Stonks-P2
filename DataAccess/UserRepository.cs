using Models;

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

    }
    public User GetUserById(int userID)
    {

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