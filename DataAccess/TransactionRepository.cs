using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;
using DataAccess;

namespace DataAccess;

public class TransactionRepository : ITransactionDAO
{
    private readonly StonksDbContext _context;
    public TransactionRepository(StonksDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetAllTransactions()
    {
        return await _context.Transactions.ToListAsync();
    }
    public async Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id)
    {
        return await _context.Transactions.ToListAsync();
    }
    public async Task<bool> CreateTransaction(Transaction transaction)
    {
         try
        {
            _context.Add(transaction);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
        return true;
    }
    public async Task<bool> UpdateTransaction(Transaction transaction)
    {
        try
        {
            _context.Update(transaction);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
        return true;
    }
}