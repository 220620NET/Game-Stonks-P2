using Services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers;
public class AuthController
{
    private readonly AuthService _service;
    public AuthController(AuthService service)
    {
        _service = service;
    }

    public async Task<IResult> Register(User userRegister)
    {
        if (userRegister.Name == null)
        {
            return Results.BadRequest("Name cannot be null");
        }
        try
        {
            await _service.Register(userRegister);
            return Results.Created("/register", userRegister);
        }
        catch (DuplicateRecordException)
        {
            return Results.Conflict("User with this name already exists");
        }
    }

        public async Task<IResult> Login(User findUser)
    {
        if (findUser.Name == null)
        {
            return Results.BadRequest("Name cannot be null");
        }
        try
        {
            return Results.Ok(await _service.LogIn(findUser));
        }
        catch (InvalidCredentialException)
        {
            return Results.NoContent();
        }
    }
}