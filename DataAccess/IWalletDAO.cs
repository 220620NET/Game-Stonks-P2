using Models;

namespace DataAccess;

public interface IWalletDAO
{
    List<Wallet> GetAllWallets();
    bool CreateWallet(Wallet wallet);
    List<Wallet> GetAllWellsByUserId(int user_id);
    bool UpdateWallet(Wallet wallet);

}