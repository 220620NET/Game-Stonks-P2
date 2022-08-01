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
        // try
        // {
        //     Task<List<Wallet>> allwallet =  _service.GetAllWallets();
        // }
        // catch
        // {
        //     Results.BadRequest();
        // }
        // return Results.Ok(allwallets);
        var allwallets =  _service.GetAllWallets();
        return allwallets.Result.Count > 0 ? Results.Ok(allwallets) : Results.NoContent();

        
    }
    public IResult GetAllWalletsByUserId(int user_id)
    {
        // try
        // {
        //     Task<List<Wallet>> wallets = _service.GetAllWalletsByUserId(user_id);
        // }
        // catch
        // {
        //     Results.BadRequest();
        // }
        // return Results.Ok(wallets);
        Task<List<Wallet>> wallets = _service.GetAllWalletsByUserId(user_id);
        return wallets.Result.Count > 0 ? Results.Ok(wallets) : Results.NoContent();
    }
    public IResult CreateWallet(Wallet wallet)
    {
        try
        {
            Task<bool> createdWallet = _service.CreateWallet(wallet);
        }
        catch
        {
            Results.BadRequest(wallet);
        }
        return Results.Ok(wallet);;
    }
    public IResult UpdateWallet(Wallet wallet)
    {

    }
}