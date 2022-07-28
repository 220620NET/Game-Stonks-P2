using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class WalletRepository : IWalletDAO
{
    private readonly StonksDbContext _context;
    public WalletRepository(StonksDbContext context)
    {
        _context = context;
    }
    public List<Wallet> GetAllWallets()
    {

    }
    public List<Wallet> GetAllWellsByUserId(int user_id)
    {

    }
    public bool CreateWallet(Wallet wallet)
    {

    }
    public bool UpdateWallet(Wallet wallet)
    {

    }
    
}