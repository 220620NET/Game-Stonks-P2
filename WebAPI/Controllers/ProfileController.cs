using Services;
using CustomExceptions;
using DataAccess;
using Models;

namespace WebAPI.Controllers;
public class ProfileController
{
    private readonly ProfileServices _services;

    public ProfileController(ProfileServices services)
    {
        _services = services;
    }

    public async Task<IResult> GetAllProfiles()
    {
        try
        {
            List<Profile> listedProfiles = await _services.GetAllProfiles();
            return Results.Accepted("/profile", listedProfiles);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound("We don't see a profile. Let's create one.");
        }
    }

    public async Task<IResult> GetProfileById(int profile_id)
    {
        try
        {
            var listedProfile = await _services.GetProfileById(profile_id);
            return Results.Accepted("/profile/wallet/{listedProfile}", profile_id);
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("We don't see a profile. Let's create one.");
        }
    }

    public async Task<IResult> GetProfileByUserId(int user_id)
    {
        try
        {
            var listedProfiles = await _services.GetProfileByUserId(user_id);
            return Results.Accepted("/profile/currency/{ListTransaction}", user_id);
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("That wallet does have any transactions.");
        }
    }

    public async Task<IResult> CreateProfile(Profile profile)
    {
        try
        {
            return Results.Accepted("/submit/profile", await _services.CreateProfile(profile));
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("Could not create profile.");
        }
    }

    public async Task<IResult> UpdateProfile(Profile profile)
    {
        try
        {
            return Results.Accepted("/update/profile", await _services.UpdateProfile(profile));
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("Could not update profile.");
        }
    }
}