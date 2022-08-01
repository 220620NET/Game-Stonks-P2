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
    public async Task<IResult> GetAllWallets()
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
        var allwallets =  await _service.GetAllWallets();
        return allwallets.Result.Count > 0 ? Results.Ok(allwallets) : Results.NoContent();

        
    }
    public async Task<IResult> GetAllWalletsByUserId(int user_id)
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
        Task<List<Wallet>> wallets = await _service.GetAllWalletsByUserId(user_id);
        return wallets.Result.Count > 0 ? Results.Ok(wallets) : Results.BadRequest();
    }
    public async Task<IResult> CreateWallet(Wallet wallet)
    {
        // try
        // {
        //     Task<bool> createdWallet = _service.CreateWallet(wallet);
        // }
        // catch
        // {
        //     Results.BadRequest(wallet);
        // }
        // return Results.Ok(wallet);;
        Task<bool> createdWallet = await _service.CreateWallet(wallet);
        return createdWallet.Result == true ? Results.Ok(wallet) : Results.BadRequest();
    }
    public async Task<IResult> UpdateWallet(Wallet wallet)
    {
        Task<bool> updatedWallet = await _service.UpdateWallet(wallet);
        return updatedWallet.Result == true ? Results.Ok(wallet) : Results.BadRequest();

    }
}