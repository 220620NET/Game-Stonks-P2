using DataAccess.Entities;
using DataAccess;
using Models;
using CustomExceptions;

namespace Services;

public class WalletServices
{
    private readonly IWalletDAO _repo;

    public WalletServices(IWalletDAO repo)
    {
        _repo = repo;
    }
    public async Task<List<Wallet>> GetAllWallets()
    {
        return _repo.GetAllWallets();
    }
    public async Task<List<Wallet>> GetAllWalletsByUserId(int user_id)
    {
        return GetAllWalletsByUserId(user_id);   
    }
    public async Task<bool> CreateWallet(Wallet wallet)
    {
        return CreateWallet(wallet);
    }
    public async Task<bool> UpdateWallet(Wallet wallet)
    {
        return UpdateWallet(wallet);
    }
}