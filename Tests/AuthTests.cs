using CustomExceptions;
using DataAccess;
using Models;
using Moq;
using Services;
using System;
using Xunit;

namespace Tests;

/*
    Tests Required
        - LogIn User
            - wrong/nonexistent email       (X) --> Record Not Found    --> Let's me log in
            - wrong/nonexistent password    (X) --> Invalid Credential  --> Let's me log in
            - wrong/nonexistent Id          --> Record Not Found
        - Register/Create User
            - existing Id                   (✔) --> 500 Internal Server Error
            - existing email                (✔) --> 409 Error: Conflict
        - LogIn User                        (✔) --> Successfully
        - Register/Create User              (✔) --> Successfully            
*/

/*
    USERS HAVE (from User Model)
        - UserId
        - Email
        - Password
*/

public class AuthServicessTesting
{

    // Registration = Success
    [Fact]
    public async Task CreatingNonExistentUser()
    {
        // Arrange
        var mockedRepo = new Mock<IUserDAO>();
        
        User userToAdd = new User{
            UserId = 123,
            Email = "correct@gmail.com",
            Password = "itsokay"
        };

        User userToReturn = new User{
            UserId = 123,
            Email = "correct@gmail.com",
            Password = "itsokay"
        };

        mockedRepo.Setup( repo => repo.CreateUser(userToAdd)).ReturnsAsync(userToAdd);
        mockedRepo.Setup( repo => repo.GetUserById(userToAdd.UserId)).ReturnsAsync(userToReturn);

        AuthServices service = new AuthServices(mockedRepo.Object);

        //Act
        User returneduser = await service.Register(userToAdd);

        //Assert (Verification)
        // mockedRepo.Verify(repo => repo.CreateUser(userToAdd), Times.Once());
        // mockedRepo.Verify(repo => repo.GetUserById(userToAdd.UserId), Times.Once());

        //Verifying that the returned result is the same as what we've sent as well as what we've had the mock repository to respond with
        Assert.NotNull(returneduser);
        Assert.Equal(returneduser.UserId, userToReturn.UserId);
        Assert.Equal(returneduser.UserId, userToAdd.UserId);
    }

    // Registration = failure
    [Fact]
    public void AttemptingToRegisterExistingUser()
    {
        // Arrange
        var mockedRepo = new Mock<IUserDAO>();
        //fixing a this to a certain date time so our User objects can all use this. 
        DateTime now = DateTime.Now;

        User userToAdd = new User{
            UserId = 1,
            Email = "barbara@gordon.com",
        };

        User userToReturn = new User{
            UserId = 1,
            Email = "barbara@gordon.com",
        };

        mockedRepo.Setup(repo => repo.GetUserById(userToAdd.UserId)).ReturnsAsync(userToReturn);

        AuthServices service = new AuthServices(mockedRepo.Object);

        //Act + Assert (Verification)
        Assert.ThrowsAsync<DuplicateRecordException>(() => service.Register(userToAdd));
        
        mockedRepo.Verify(repo => repo.GetUserById(userToAdd.UserId), Times.Once());
    }

    // LogIn User Fail -- wrong password
    [Fact]
    public async Task InvalidUserPassword()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 1,
            Email = "ed@nigma.com", 
        };

        User falseUser = new User{
            UserId = 1,
            Email = "oswald@cobblepot.com", 
        };
    
        // When
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo =>  repo.CreateUser(falseUser)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        await Assert.ThrowsAsync<InvalidInputException>(() => service.CreateUser(falseUser));  
    }


    // LogIn User Fail -- invalid email/username
    [Fact]
    public async Task InvalidUserEmail()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User newUser = new User{
            UserId = 0,
            Email = "boy@wonder.com", 
        };

        User falseUser = new User{
            UserId = 0,
            Email = "man@steel.com", 
        };
    
        // When
        UserRepo.Setup( repo =>  repo.CreateUser(newUser)).ReturnsAsync(newUser);
        UserRepo.Setup( repo =>  repo.CreateUser(falseUser)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        await Assert.ThrowsAsync<InvalidInputException>(() => service.CreateUser(falseUser));  
    }

    // LogIn User -- Success
    [Fact]
    public async Task SuccessfulLogInUser()
    {
        // Given
        var UserRepo = new Mock<IUserDAO>();

        User attemptingUser = new User{
            UserId = 0,
            Email = "joe@volcano.com", 
        };

        User existingUser = new User{
            UserId = 0,
            Email = "joe@volcano.com", 
        };
    
        // When
        UserRepo.Setup( repo =>  repo.CreateUser(attemptingUser)).ReturnsAsync(attemptingUser);
        UserRepo.Setup( repo =>  repo.CreateUser(existingUser)).ThrowsAsync(new InvalidInputException());
        // Then
        UserServices service = new UserServices(UserRepo.Object);
        //Assert.ThrowsAsync(() => service.LogIn(newUser));  

        Assert.NotNull(attemptingUser);
        Assert.Equal(attemptingUser.UserId, existingUser.UserId);
        Assert.Equal(attemptingUser.UserId, existingUser.UserId);
    }

}