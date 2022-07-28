using Models;

namespace DataAccess;

public interface IProfileDAO
{
    List<Profile> GetAllProfiles();
    Profile GetProfileById(int profile_id);
    Profile GetProfileByUserId(int user_id);
    Profile GetProfileByFirstName(string firstname);
    bool CreateProfile(Profile profile);
    bool UpdateProfile(Profile profile);
}