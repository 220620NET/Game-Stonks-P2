using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;

namespace Tests;

public class ProfileTest
{
    [Fact]
    public void NoProfilesToGet()
    {
        var mockedRepo = new Mock<IProfileDAO>();


        mockedRepo.Setup( repo =>  repo.GetAllProfiles()).Throws(new ResourceNotFoundException());


        ProfileServices service = new ProfileServices(mockedRepo.Object);

        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllProfiles());
    }

    [Fact]
    public async Task WrongProfileId()
    {
        var profileRepo = new Mock<IProfileDAO>();

        Profile newProfile = new Profile{
            ProfileId = 1,
            UserIdFk = 1, 
            FirstName = "",
            LastName = ""
        };

        profileRepo.Setup( repo =>  repo.CreateProfile(newProfile)).ReturnsAsync(true);
        profileRepo.Setup( repo => repo.GetAllProfileByUserId(2)).ThrowsAsync(new RecordNotFoundException());

        ProfileServices service = new ProfileServices(p.Object);

        Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetAllProfilesByUserId(2));  
    }
    public async Task WrongProfileByUserId()
    {
        var profileRepo = new Mock<IProfileDAO>();

        Profile newProfile = new Profile{
            ProfileId = 1,
            UserIdFk = 1, 
            FirstName = "",
            LastName = ""
        };

        profileRepo.Setup( repo =>  repo.CreateProfile(newProfile)).ReturnsAsync(true);
        profileRepo.Setup( repo => repo.GetAllProfileByUserId(2)).ThrowsAsync(new RecordNotFoundException());

        ProfileServices service = new ProfileServices(p.Object);

        Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetAllProfilesByUserId(2));  
    }
    [Fact]
    public async Task InvalidCreatedProfile()
    {
        // Given
        var profileRepo = new Mock<IProfileDAO>();

        Profile newProfile = new Profile{
            ProfileId = 1,
            UserIdFk = 1, 
            FirstName = "",
            LastName = ""
        };

        Profile falseProfile = new Profile{
            ProfileId = 1,
            UserIdFk = 1, 
            FirstName = "",
            LastName = ""
        };
    
        // When
        p.Setup( repo =>  repo.CreateProfile(newProfile)).ReturnsAsync(true);
        p.Setup( repo =>  repo.CreateProfile(falseProfile)).ThrowsAsync(new InvalidInputException());
        // Then
        ProfileServices service = new ProfileServices(p.Object);

        Assert.ThrowsAsync<InvalidInputException>(() => service.CreateProfile(falseProfile));  
    }
        [Fact]
    public async Task FailToUpdateProfile()
    {
        // Given
        var p = new Mock<IProfileDAO>();

        Profile newProfile = new Profile{
            ProfileId = 1,
            UserIdFk = 1, 
            FirstName = "",
            LastName = ""
        };

        Profile toUpdate = new Profile{
            ProfileId = 1,
            UserIdFk = 1, 
            FirstName = "",
            LastName = ""
        };
    
        // When
        profileRepo.Setup( repo =>  repo.CreateProfile(newProfile)).ReturnsAsync(true);
        profileRepo.Setup( repo =>  repo.CreateProfile(toUpdate)).ThrowsAsync(new InvalidInputException());
        // Then
        ProfileServices service = new ProfileServices(profileRepo.Object);

        Assert.ThrowsAsync<InvalidInputException>(() => service.CreateWallet(toUpdate));  
        // INF loop somewhere!!!
    }
}