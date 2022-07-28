using Models;

namespace DataAccess;

public interface ITransactionDAO
{
    Task<List<Transaction>> GetAllTransactions();
    Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id);
    Task<bool> CreateTransaction(Transaction transaction);
    Task<bool> UpdateTransaction(Transaction transaction);

}