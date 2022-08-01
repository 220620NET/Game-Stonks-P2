using DataAccess.Entities;
using Services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers;

public class WalletController
{
    private readonly WalletServices _service;

    public WalletController(WalletServices service)
    {
        _service = service;
    }
    public IResult GetAllWallets()
    {

    }
    public IResult GetAllWalletsByUserId(int user_id)
    {
  
    }
    public IResult CreateWallet(Wallet wallet)
    {

    }
    public IResult UpdateWallet(Wallet wallet)
    {

    }
}