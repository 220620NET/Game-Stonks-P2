using CustomExceptions;
using DataAccess;
using Models;
using Moq;
using Services;
using System;
using Xunit;

UserIdspace Tests;

/*
    Tests Required
        - LogIn User
            - wrong/nonexistent email       --> Record Not Found
            - wrong/nonexistent password    --> Invalid Credential
            - wrong/nonexistent Id          --> Record Not Found
        - Register/Create User
            - existing Id                   --> Duplicate Record
            - Something else goes wrong    --> Invalid Input
*/

/*
    USERS HAVE (from User Model)
        - UserId
        - Email
        - Profiles
        - Wallets
*/

public class AuthServicesTesting
{

    // NEED LogIn success test and LogIn failure test
    
    // Successful registration 
    [Fact]
    public async Task CreatingNonExistentUser()
    {
        // Arrange
        var mockedRepo = new Mock<UserRepository>();
ƒ
        User userToAdd = new User{
            UserId = 123,
            Email = 2,
            Wallets = 100,
            Profiles = 4
        };

        User userToReturn = new User{
            UserId = 123,
            Email = 2,
            Wallets = 100,
            Profiles = 4
        };

        mockedRepo.Setup(repo => repo.GetUserById(userToAdd.UserId)).Throws(new RecordNotFoundException());
        mockedRepo.Setup(repo => repo.CreateUser(userToAdd)).Returns(userToReturn);

        AuthService service = new AuthService(mockedRepo.Object);

        //Act
        User returneduser = await service.Register(userToAdd);

        //Assert (Verification)
        mockedRepo.Verify(repo => repo.GetUser(userToAdd.UserId), Times.Once());
        mockedRepo.Verify(repo => repo.CreateUser(userToAdd), Times.Once());

        //Verifying that the returned result is the same as what we've sent as well as what we've had the mock repository to respond with
        Assert.NotNull(returneduser);
        Assert.Equal(returneduser.Id, userToReturn.Id);
        Assert.Equal(returneduser.UserId, userToAdd.UserId);
    }

    // Registration failure
    [Fact]
    public void AttemptingToRegisterExistingUser()
    {
        // Arrange
        var mockedRepo = new Mock<IuserRepository>();
        //fixing a this to a certain date time so our User objects can all use this. 
        DateTime now = DateTime.Now;

        User userToAdd = new User{
            UserId = "test  user",
            Email = 2,
            Wallets = 100,
            Profiles = now
        };

        User userToReturn = new User{
            Id = 1,
            UserId = "test  user",
            Email = 2,
            Wallets = 100,
            Profiles = now
        };

        mockedRepo.Setup(repo => repo.GetUserById(userToAdd.UserId)).ReturnsAsync(userToReturn);

        AuthService service = new AuthService(mockedRepo.Object);

        //Act + Assert (Verification)
        Assert.ThrowsAsync<DuplicateRecordException>(() => service.CreateUser(userToAdd));
        
        mockedRepo.Verify(repo => repo.GetUserById(userToAdd.UserId), Times.Once());
    }
}