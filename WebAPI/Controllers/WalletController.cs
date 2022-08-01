using Models;
using Services;
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
        List<Wallet> allwallets = _service.GetAllWallets();
        
        return allwallets.Count > 0 ? Results.Ok(allwallets) : Results.NoContent();
    }
    public IResult GetAllWalletsByUserId(int user_id)
    {
        List<Wallet> wallets = _service.GetAllWalletsByUserId(user_id);
        return wallets.Count > 0 ? Results.Ok(wallets) : Results.NoContent();
    }
    public IResult CreateWallet(Wallet wallet)
    {

    }
    public IResult UpdateWallet(Wallet wallet)
    {

    }
}