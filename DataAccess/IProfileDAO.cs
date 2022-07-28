using Models;

namespace DataAccess;

public interface IProfileDAO
{
    public List<Profile> GetAllProfiles();
    public Profile GetProfileById(int profile_id);
    public Profile GetProfileByUserId(int user_id);
    public bool CreateProfile(Profile profile);
    public bool UpdateProfile(Profile profile);
}