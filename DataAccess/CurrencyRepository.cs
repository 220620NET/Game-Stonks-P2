using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class CurrencyRepository : ICurrencyDAO
{
    private readonly StonksDbContext _context;
    public CurrencyRepository(StonksDbContext context)
    {
        _context = context;
    }

    public List<Currency> GetAllCurrencies()
    {

    }
    public Currency GetCurrencyById(int currency_id)
    {

    }
    public Currency GetCurrencyBySymbol(string symbol)
    {

    }
    public bool CreateCurrency(Currency currency)
    {

    }
    public bool UpdateCurrency(Currency currency)
    {
        
    }
}