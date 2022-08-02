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
        try
        {
            return await _repo.GetAllWallets();
        }
        catch (RecordNotFoundException)
        {   
            throw new RecordNotFoundException();
        }
    }
    public async Task<List<Wallet>> GetAllWalletsByUserId(int user_id)
    {
        try
        {
            return await GetAllWalletsByUserId(user_id);   
        }
        catch (RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
    }
    public async Task<bool> CreateWallet(Wallet wallet)
    {
        try
        {
            return await CreateWallet(wallet);
        }
        catch (InvalidInputException)
        {
            throw new InvalidInputException();
        }
    }
    public async Task<bool> UpdateWallet(Wallet wallet)
    {
        try
        {
            return await UpdateWallet(wallet);
        }
        catch (InvalidInputException)
        { 
            throw new InvalidInputException();
        }
    }
}