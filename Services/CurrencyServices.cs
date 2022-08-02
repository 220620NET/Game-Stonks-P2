using DataAccess;
using Models;
using CustomExceptions;

namespace Services;

public class CurrencyServices
{
    private readonly ICurrencyDAO _repo;

    public CurrencyServices(ICurrencyDAO repo)
    {
        _repo = repo;
    }
    public async Task<List<Currency>> GetAllCurrencies()
    {
        try
        {
            return await _repo.GetAllCurrencies();
        }
        catch (RecordNotFoundException)
        {   
            throw;
        }
    }
    public async Task<Currency> GetCurrencyById(int currency_id)
    {
        try
        {
            return await GetCurrencyById(currency_id);   
        }
        catch (RecordNotFoundException)
        {
            throw;
        }
    }
    public async Task<Currency> GetCurrencyBySymbol(string symbol)
    {
        try
        {
            return await GetCurrencyBySymbol(symbol);
        }
        catch (InvalidInputException)
        {
            throw;
        }
    }
    public async Task<bool> CreateCurrency(Currency currency)
    {
        try
        {
            return await CreateCurrency(currency);
        }
        catch (InvalidInputException)
        {
            throw;
        }
    }
    public async Task<bool> UpdateCurrency(Currency currency)
    {
        try
        {
            return await UpdateCurrency(currency);
        }
        catch (InvalidInputException)
        { 
            throw;
        }
    }
}