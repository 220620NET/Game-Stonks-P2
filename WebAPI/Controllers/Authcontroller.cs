using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class AuthController
{
    private readonly AuthServices _service;
    public AuthController(AuthServices service)
    {
        _service = service;
    }

    public IResult Register(User user)
    {
        if(user.UserId == null)
        {
            return Results.BadRequest("UserId cannot be null");
        }
        try
        {
            _service.Register(user);
            return Results.Created("Register", user);
        }
        catch(DuplicateRecordException)
        {
            return Results.Conflict("This UserId already exists");
        }
    }

    public IResult Login(User user)
    {
        if(user.UserId == null)
        {
            return Results.BadRequest("UserId cannot be null");
        }
        try
        {
            return Results.Ok(_service.Login(user.UserId, user.Password));
        }
        catch(InvalidCredentialException)
        {
            return Results.NoContent();
        }
    }
}