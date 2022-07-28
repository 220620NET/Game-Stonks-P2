using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class AuthServices
{
    private readonly IUserDAO _user;

    public AuthServices(IUserDAO userDao)
    {
        _user = userDao;
    }
}