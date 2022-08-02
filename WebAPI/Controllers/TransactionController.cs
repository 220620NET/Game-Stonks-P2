using Services;
using CustomExceptions;
using DataAccess;
using Models;

namespace WebAPI.Controllers;
public class TransactionController
{
    private readonly TransactionServices _Services;

    public TransactionController(TransactionServices services)
    {
        _Services = services;
    }

    public async Task<IResult> GetAllTransactions()
    {
        try
        {
            List<Transaction> ListTransactions = await _Services.GetAllTransactions();
            return Results.Accepted("/transaction", ListTransactions);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound("There are no transactions.");
        }
    }

    public async Task<IResult> GetAllTransactionsByWalletId(int wallet_id)
    {
        try
        {
            List<Transaction> ListTransactions = await _Services.GetAllTransactionsByWalletId(wallet_id);
            return Results.Accepted("/transaction/wallet/{ListTransaction}", wallet_id);
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("That wallet does have any transactions.");
        }
    }

    public async Task<IResult> GetAllTransactionsByCurrencyId(int currency_id)
    {
        try
        {
            List<Transaction> ListTransactions = await _Services.GetAllTransactionByCurrencyId(currency_id);
            return Results.Accepted("/transaction/currency/{ListTransaction}", currency_id);
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("That wallet does have any transactions.");
        }
    }

    public async Task<IResult> CreateTransaction(Transaction transaction)
    {
        try
        {
            return Results.Accepted("/submit/transaction", await _Services.CreateTransaction(transaction));
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("Could not create transaction.");
        }
    }

    public async Task<IResult> UpdateTransaction(Transaction transaction)
    {
        try
        {
            return Results.Accepted("/update/transaction", await _Services.UpdateTransaction(transaction));
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("Could not update transaction.");
        }
    }
}