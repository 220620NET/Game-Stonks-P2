using Models;

namespace DataAccess;

public interface IWalletDAO
{
    public List<Wallet> GetAllWallets();
    public List<Wallet> GetAllWellsByUserId(int user_id);
    public bool CreateWallet(Wallet wallet);
    public bool UpdateWallet(Wallet wallet);

}