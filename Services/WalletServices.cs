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
        return await _repo.GetAllWallets();
    }
    public async Task<List<Wallet>> GetAllWalletsByUserId(int user_id)
    {
        return await GetAllWalletsByUserId(user_id);   
    }
    public async Task<bool> CreateWallet(Wallet wallet)
    {
        return await CreateWallet(wallet);
    }
    public async Task<bool> UpdateWallet(Wallet wallet)
    {
        return await UpdateWallet(wallet);
    }
}