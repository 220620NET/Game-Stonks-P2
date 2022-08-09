using Models;

namespace DataAccess;

public interface ITransactionDAO
{
    Task<List<Transaction>> GetAllTransactions();
    Task<Transaction> GetTransactionById(int id);
    Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id);
    Task<List<Transaction>> GetAllTransactionsByCurrencyId(int currency_id);
    Task<bool> CreateTransaction(Transaction transaction);
    Task<bool> UpdateTransaction(Transaction transaction);

}