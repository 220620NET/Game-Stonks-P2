using Models;

namespace DataAccess;

public interface Transaction
{
    public List<Transaction> GetAllTransactions();
    public List<Transaction> GetAllTransactionsByWalletId(int wallet_id);
    public List<Transaction> GetTransactionsByType(string type);
    public bool CreateTransaction(Transaction transaction);
    public bool UpdateTransaction(Transaction transaction);

}