using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class ProfileRepository : IProfileDAO
{
    private readonly StonksDbContext _context;
    public ProfileRepository(StonksDbContext context)
    {
        _context = context;
    }
    public List<Profile> GetAllProfiles()
    {

    }
    public Profile GetProfileById(int profile_id)
    {

    }
    Profile GetProfileByFirstName(string firstname)
    {
        
    }
    public Profile GetProfileByUserId(int user_id)
    {

    }
    public bool CreateProfile(Profile profile)
    {

    }
    public bool UpdateProfile(Profile profile)
    {

    }
}