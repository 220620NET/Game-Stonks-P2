using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class TransactionRepository : ITransactionDAO
{
    private readonly StonksDbContext _context;
    public TransactionRepository(StonksDbContext context)
    {
        _context = context;
    }

    public List<Transaction> GetAllTransactions()
    {

    }
    public List<Transaction> GetAllTransactionsByWalletId(int wallet_id)
    {

    }
    public List<Transaction> GetTransactionsByType(string type)
    {

    }
    public bool CreateTransaction(Transaction transaction)
    {

    }
    public bool UpdateTransaction(Transaction transaction)
    {
        
    }
}