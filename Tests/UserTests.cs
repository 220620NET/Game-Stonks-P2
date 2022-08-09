using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;

namespace Tests;

/*
    TESTS REQUIRED
        - GetAllUsers
        - GetUserById
        - GetUserByEmail
        - UpdateUser
*/

/*
    USERS HAVE (from User Model)
        - UserId
        - Email
        - Profiles
        - Wallets
*/

public class UserTesting
{

    // Do all of these tests fail? Succeed? Both? 

    // GetAllUsers

    [Fact]
    public void NoUserToGet()
    {
        // WHERE does it get the mock information from?
        var mockedRepo = new Mock<IUserDAO>();
        mockedRepo.Setup( repo =>  repo.GetAllUsers()).Throws(new ResourceNotFoundException());
        UserServices service = new UserServices(mockedRepo.Object);
        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllUsers());
    }

    // GetUserById
    
    [Fact]
    public async Task WrongUserId()
    {
        var UserRepo = new Mock<IUserDAO>();
        User newUser = new User

        // I can't tell from Models what should go here

        {
            UserId = a123,              // shouldn't have letter
            Email = autumn@gmail.snot,  // "snot not valid
            Prilfes = 1,                // this should be profles, right? What table? What datatype?
            Wallets = 10                // What table? What datatype?
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        UserRepo.Setup( repo => repo.GetAllUsersByUserId(2)).ThrowsAsync(new RecordNotFoundException());
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetAllUsersByUserId(2));  
    }


    // GetUserByEmail
    [Fact]
    public async Task InvalidCreateUser()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 1,
            Email = 1, 
            Prilfes = 1,    // this should be profles, right?
            Wallets = 10    // so this should be number of wallets, right?
        };

        User falseUser = new User{
            UserId = 1,
            Email = 1, 
            Prilfes = 1,    // this should be profles, right?
            Wallets = 10
        };
    
        // When
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        UserRepo.Setup( repo =>  repo.CreateUser(falseUser)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync<InvalidInputException>(() => service.CreateUser(falseUser));  
    }


    // UpdateUser
    [Fact]
    public async Task FailToUpdateUser()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 1,
            Email = 1, 
            Prilfes = 1,    // this should be profles, right?
            Wallets = 10
        };

        User toUpdate = new User{
            UserId = 1,
            Email = 1, 
            Prilfes = 1,    // this should be profles, right?
            Wallets = 10
        };
    
        // If
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        UserRepo.Setup( repo =>  repo.CreateUser(toUpdate)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync<InvalidInputException>(() => service.CreateUser(toUpdate));  
    }
}