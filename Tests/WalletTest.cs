using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;

namespace Tests;

public class WalletTesting
{
    [Fact]
    public void NoWalletsToGet()
    {
        var mockedRepo = new Mock<IWalletDAO>();


        mockedRepo.Setup( repo =>  repo.GetAllWallets()).Throws(new ResourceNotFoundException());


        WalletServices service = new WalletServices(mockedRepo.Object);

        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllWallets());

    }
    [Fact]
    public void WrongWalletId()
    {
        var walletRepo = new Mock<IWaletDAO>();
        var userRepo = new Mock<IUserDAO>();
        var currencyRepo = new Mock<ICurrencyDAO>();

       
        User newUser = new User{
            UserId = 1,
            Email = "kishanp575@gmail.com",
            Password = "password"
        };
        Currency newCurrency = new Currency{
            CurrencyId = 1,
            CurrencySymbol = "BTC",
            CurrencyCurrentPrice = 10,
            CurrencyTime = DateTime.Now
        };
        Wallet newWallet = new Wallet{
            WalletId = 1,
            UserIdFk = 1, 
            CurrencyIdFk = 1,
            AmountCurrency = 10
        };

        userRepo.Setup( repo => repo.createUser(newUser)).Returns(newUser);
        currencyRepo.Setup( userRepo => repo.CreateCurrency(newCurrency)).Returns(newCurrency);
        walletRepo.Setup( repo => repo.CreateWallet(newWallet)).Returns(newWallet);
        walletRepo.Setup( userRepo => repo.GetAllWalletsByUserId(2)).Returns(new RecordNotFoundException());

        WalletServies service = new WalletServies(walletRepo.Object);

        Assert.ThrowsAsync<RecordNotFoundException>(async () => await service.GetAllWalletsByUserId(2));
    
    }
}