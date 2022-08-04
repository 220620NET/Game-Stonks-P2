using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class AuthServices 
{
    private readonly IUserDAO _userdao;

    public AuthServices(IUserDAO userDao)
    {
        _userdao = userDao;
    }
    public async Task<User> Register(User findUser)
    {
        try
        {
            await _userdao.GetUserByEmail(findUser.Email);
            throw new DuplicateRecordException();
        }
        catch
        {
            return _userdao.CreateUser(findUser);
        }
    }
    public async Task<User> LogIn(User loginUser)
    {
        try
        {
            User foundUser = await _userdao.GetUserByEmail(loginUser.Email);
            return foundUser;
        }
        catch(RecordNotFoundException)
        {
            throw new InvalidCredentialException();
        }
    }
}