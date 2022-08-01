using Models;

namespace DataAccess;

public interface IUserDAO
{
    List<User> GetAllUsers();
    User GetUserById(int userID);
    User GetUserByEmail(string email);
    bool CreateUser(User user);
    bool UpdateUser(User user);
}
