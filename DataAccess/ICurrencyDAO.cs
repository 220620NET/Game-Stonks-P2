using Models;

namespace DataAccess;

public interface ICurrencyDAO
{
    public List<Currency> GetAllCurrencies();
    public Currency GetCurrencyById(int currency_id);
    public Currency GetCurrencyBySymbol(string symbol);
    public bool CreateCurrency(Currency currency);
    public bool UpdateCurrency(Currency currency);
}