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
        return await _context.Transactions.AsNoTracking().Where(Transaction => Transaction.WalletIdFk == wallet_id).ToListAsync();
    }
    public async Task<List<Transaction>> GetAllTransactionsByCurrencyId(int currency_id)
    {
        return await _context.Transactions.AsNoTracking().Where(Transaction => Transaction.CurrencyIdFk == currency_id).ToListAsync();
    }
    public async Task<bool> CreateTransaction(Transaction transaction)
    {
        _context.Add(transaction);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
    public async Task<bool> UpdateTransaction(Transaction transaction)
    {
        _context.Update(transaction);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
}