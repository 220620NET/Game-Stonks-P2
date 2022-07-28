using Models;

namespace DataAccess;

public interface IUserDAO
{
    public List<User> GetAllUsers();
    public User GetUserById(int userID);
    public User GetUserByUsername(string username);
    public bool CreateUser(User user);
    public bool UpdateUser(User user);
}

public interface IProfileDAO
{
    public List<Profile> GetAllProfiles();
    public Profile GetProfileById(int profile_id);
    public Profile GetProfileByUserId(int user_id);
    public bool CreateProfile(Profile profile);
    public bool UpdateProfile(Profile profile);
}

public interface ICurrencyDAO
{
    public List<Currency> GetAllCurrencies();
    public Currency GetCurrencyById(int currency_id);
    public Currency GetCurrencyBySymbol(string symbol);
    public bool CreateCurrency(Currency currency);
    public bool UpdateCurrency(Currency currency);
}

public interface Transaction
{
    public List<Transaction> GetAllTransactions();
    public List<Transaction> GetAllTransactionsByWalletId(int wallet_id);
    public List<Transaction> GetTransactionsByType(string type);
    public bool CreateTransaction(Transaction transaction);
    public bool UpdateTransaction(Transaction transaction);

}