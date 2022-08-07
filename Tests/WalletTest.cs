using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;
using System;

namespace Tests;

public class WalletTesting
{
    [Fact]
    public void GetAllWalletstest()
    {
        var mockedRepo = new Mock<IWalletDAO>();


        mockedRepo.Setup( repo =>  repo.GetAllWallets()).Throws(new ResourceNotFoundException());


        WalletServices service = new WalletServices(mockedRepo.Object);

        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllWallets());

    }
}