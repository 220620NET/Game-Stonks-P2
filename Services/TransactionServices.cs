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
            throw new RecordNotFoundException();
        }
    }

    public Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id)
    {
        try
        {
            return _transactionDAO.GetAllTransactions();
        }
        catch(RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
    }

    public Task<bool> CreateTransaction(Transaction create)
    {
        try
        {
            return _transactionDAO.CreateTransaction(create);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }

    public Task<bool> UpdateTransaction (Transaction create)
    {
        try
        {
            return _transactionDAO.UpdateTransaction(create);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }

}