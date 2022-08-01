using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class UserServices
{
    private readonly IUserDAO _userRepo;

    public UserServices(IUserDAO repo)
    {
        _userRepo = repo;
    }

    public List<User> GetAllUsers()
    {
        return _userRepo.GetAllUsers();
    }

    public User GetUserById(int userID)
    {
        return _userRepo.GetUserById(userID);
    }
    public User GetUserByEmail(string email)
    {
        return _userRepo.GetUserByEmail(email);
    }
    public User CreateUser(User user)
    {
        return _userRepo.CreateUser(user);
    }
    public User UpdateUser(User user)
    {
        return _userRepo.UpdateUser(user);
    }
}