using Models;

namespace DataAccess;

public interface ICurrencyDAO
{
    List<Currency> GetAllCurrencies();
    Currency GetCurrencyById(int currency_id);
    Currency GetCurrencyBySymbol(string symbol);
    bool CreateCurrency(Currency currency);
    bool UpdateCurrency(Currency currency);
}