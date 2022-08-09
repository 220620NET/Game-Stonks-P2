using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class TransactionServices
{
    private readonly ITransactionDAO _transactionDAO;

    public TransactionServices(ITransactionDAO transactionDAO)
    {
        _transactionDAO = transactionDAO;
    }

    public async Task<List<Transaction>> GetAllTransactions()
    {
        try
        {
            return await _transactionDAO.GetAllTransactions();
        }
        catch(RecordNotFoundException)
        {
            throw;
        }
    }
    public async Task<Transaction> GetTransactionById(int id)
    {
        try
        {
            return await _transactionDAO.GetTransactionById(id);
        }
        catch(RecordNotFoundException)
        {
            throw;
        }
    }

    public async Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id)
    {
        try
        {
            return await _transactionDAO.GetAllTransactionsByWalletId(wallet_id);
        }
        catch(RecordNotFoundException)
        {
            throw;
        }
    }
    public async Task<List<Transaction>> GetAllTransactionsByCurrencyId(int currency_id)
    {
        try
        {
            return await _transactionDAO.GetAllTransactionsByCurrencyId(currency_id);
        }
        catch(RecordNotFoundException)
        {
            throw;
        }
    }
    public async Task<bool> CreateTransaction(Transaction create)
    {
        try
        {
            return await _transactionDAO.CreateTransaction(create);
        }
        catch (ResourceNotFoundException)
        {
            throw;
        }
    }
    public async Task<bool> UpdateTransaction (Transaction create)
    {
        try
        {
            return await _transactionDAO.UpdateTransaction(create);
        }
        catch (ResourceNotFoundException)
        {
            throw;
        }
    }

}