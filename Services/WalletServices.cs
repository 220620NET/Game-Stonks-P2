using DataAccess.Entities;
using DataAccess;
using Models;

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

    }
    public async Task<List<Wallet>> GetAllWalletsByUserId(int user_id)
    {
        
    }
    public async Task<bool> CreateWallet(Wallet wallet)
    {
        
    }
    public async Task<bool> UpdateWallet(Wallet wallet)
    {
        
    }
}