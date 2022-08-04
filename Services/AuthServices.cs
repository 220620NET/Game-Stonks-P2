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
    public async Task<User> Login(int userID, string Password)
    {
        User user;
        try
        {
            user = await _user.GetUserById(userID);
            if(user.UserId == null)
            {
                throw new ResourceNotFoundException();
            }
            if(user.Password == Password)
            {
                return user;
            }
            else{
                throw new InvalidCredentialException();
            }
        }
        catch(RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
        catch(InvalidCredentialException)
        {
            throw new InvalidCredentialException();
        }
    }

    public async Task<User> Register(User newUser)
    {
        try
        {
            User attempt = await _user.GetUserById(newUser.UserId);
            
            if(attempt.UserId == newUser.UserId)
            {
                throw new DuplicateRecordException();
            }
            else    
            {
                return await _user.CreateUser(newUser);
            }
        }
        catch(DuplicateRecordException)
        {
            throw new DuplicateRecordException();                
        }
        catch(ResourceNotFoundException)
        {
            return await _user.CreateUser(newUser);
        }  
    }
}