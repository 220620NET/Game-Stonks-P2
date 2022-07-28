using Models;

namespace DataAccess;

public interface Transaction
{
    List<Transaction> GetAllTransactions();
    List<Transaction> GetAllTransactionsByWalletId(int wallet_id);
    List<Transaction> GetTransactionsByType(string type);
    bool CreateTransaction(Transaction transaction);
    bool UpdateTransaction(Transaction transaction);

}