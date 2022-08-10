using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;

namespace Tests;

/*
    TESTS REQUIRED
        - GetAllUsers       = Pass
        - GetUserById       = Pass
        - GetUserByEmail    = Pass
        - UpdateUser        = Pass
        - GetAllUsers       = ResourceNotFoundException
        - GetUserById       = RecordNotFoundException
        - GetUserByEmail    = Pass
        - UpdateUser        = InvalidInputException        
*/

/*
    USERS HAVE (from User Model)
        - UserId
        - Email
*/

public class UserTesting
{

    // GetAllUsers = Pass

    [Fact]
    public void GetAllUsers()
    {
        // WHERE does it get the mock information from? How does it get .... "all users"?
        var mockedRepo = new Mock<IUserDAO>();
        mockedRepo.Setup( repo =>  repo.GetAllUsers()).Throws(new ResourceNotFoundException());
        UserServices service = new UserServices(mockedRepo.Object);
        Assert.ThrowsAsync(async () => await service.GetAllUsers());
    }

    // GetAllUsers = Fail

    [Fact]
    public void NoUserToGet()
    {
        // WHERE does it get the mock information from? What tells the test 
        var mockedRepo = new Mock<IUserDAO>();
        mockedRepo.Setup( repo =>  repo.GetAllUsers()).Throws(new ResourceNotFoundException());
        UserServices service = new UserServices(mockedRepo.Object);
        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllUsers());
    }    

    // GetUserById = Pass
    
    [Fact]
    public async Task GetUserById()
    {
        var UserRepo = new Mock<IUserDAO>();
        User newUser = new User

        {
            UserId = 2,                     // has correct userId
            Email = "autumn@gmail.com",     // email valid
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        // This next line needs to change
        UserRepo.Setup( repo => repo.GetUserById(2)).ThrowsAsync(new RecordNotFoundException());
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync(() => service.GetUserById(2));  
    }


    // GetUserById = Fail
    
    [Fact]
    public async Task WrongUserId()
    {
        var UserRepo = new Mock<IUserDAO>();
        User newUser = new User

        {
            UserId = 8,                     // shouldn't have letter
            Email = "autumn@gmail.com",     // "snot not valid
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        UserRepo.Setup( repo => repo.GetAllUsersByUserId(2)).ThrowsAsync(new RecordNotFoundException());
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetAllUsersByUserId(2));  
    }


    // UpdateUser = Pass
    [Fact]
    public async Task SucceedToUpdateUser()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 1,
            Email = "autumn@gmail.com", 
        };

        User toUpdate = new User{
            UserId = 1,
            Email = "booger@snot.com", 
        };
    
        // If
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        UserRepo.Setup( repo =>  repo.CreateUser(toUpdate)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync<InvalidInputException>(() => service.CreateUser(newUser));  
    }


    // UpdateUser = Fail
    [Fact]
    public async Task FailToUpdateUser()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 1,
            Email = "autumn@gmail.com", 
        };

        User toUpdate = new User{
            UserId = 1,
            Email = "incorrect@wrong.com", 
        };
    
        // If
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        UserRepo.Setup( repo =>  repo.CreateUser(toUpdate)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync<InvalidInputException>(() => service.CreateUser(toUpdate));  
    }


    // GetUserByEmail = Pass
    
    [Fact]
    public async Task GetUserByEmail()
    {
        var UserRepo = new Mock<IUserDAO>();
        User newUser = new User

        // I can't tell from Models what should go here

        {
            UserId = 2,                 // correct userId
            Email = autumn@gmail.com,   // email valid
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        // UserRepo.Setup( repo => repo.GetUserByEmail("autumn@gmail.com")).ThrowsAsync(new RecordNotFoundException());
        UserServices service = new UserServices(UserRepo.Object);
        Assert.Equal(newUser.GetUserByEmail("autumn@gmail.com"));  
    }


    // GetUserById = Fail
    
    [Fact]
    public async Task WrongOrNoUserEmail()
    {
        var UserRepo = new Mock<IUserDAO>();
        User newUser = new User

        {
            UserId = 123,              
            Email = autumn@gmail.wrong,  // "wrong" not valid
        };

        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(true);
        UserRepo.Setup( repo => repo.GetUserByEmail("autumn@gmail.com")).ThrowsAsync(new RecordNotFoundException());
        UserServices service = new UserServices(UserRepo.Object);
        Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetUserByEmail("autumn@gmail.wrong"));  
    }    

}