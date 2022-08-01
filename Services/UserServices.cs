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

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepo.GetAllUsers();
    }

    public async Task<User> GetUserById(int userID)
    {
        return await _userRepo.GetUserById(userID);
    }
    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepo.GetUserByEmail(email);
    }
    public async Task<bool> CreateUser(User user)
    {
        return await _userRepo.CreateUser(user);
    }
    public async Task<bool> UpdateUser(User user)
    {
        return await _userRepo.UpdateUser(user);
    }
}
