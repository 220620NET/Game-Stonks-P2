using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;

namespace Tests;

public static class fakeDb{
    public static List<Wallet> Wallets = new List<Wallet>()
    {
        new Wallet{
            WalletId = 1,
            UserIdFk = 1, 
            CurrencyIdFk = 1,
            AmountCurrency = 10
        },
        new Wallet{
            WalletId = 2,
            UserIdFk = 2, 
            CurrencyIdFk = 1,
            AmountCurrency = 90
        }
    };

}
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
    public Task WrongWalletId()
    {
        var mockedRepo = new Mock<IWalletDAO>();
        
        mockedRepo.Setup( repo => repo.GetAllWalletsByUserId(3)).Throws(new RecordNotFoundException());

        WalletServices service = new WalletServices(mockedRepo.Object);

        Assert.ThrowsAsync<RecordNotFoundException>(async () => await service.GetAllWalletsByUserId(3));
        Assert.fail();
    }
}