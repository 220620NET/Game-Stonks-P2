using Models;

namespace DataAccess;

public interface IUserDAO
{
    public List<User> GetAllUsers();
    public User GetUserById(int userID);
    public User GetUserByUsername(string username);
    public bool CreateUser(User user);
    public bool UpdateUser(User user);
}