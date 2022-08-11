using Services;
using CustomExceptions;
using DataAccess;
using Models;

namespace WebAPI.Controllers;

/// <summary>
/// Class for transaction controller.
/// </summary>
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
        catch (RecordNotFoundException)
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
        catch (RecordNotFoundException)
        {
            return Results.BadRequest("There are no transactions in that wallet");
        }
    }

    public async Task<IResult> GetAllTransactionsByCurrencyId(int currency_id)
    {
        try
        {
            List<Transaction> ListTransactions = await _Services.GetAllTransactionsByCurrencyId(currency_id);
            return Results.Accepted("/transaction/currency/{ListTransaction}", currency_id);
        }
        catch (RecordNotFoundException)
        {
            return Results.BadRequest("There are no transactions with that currency.");
        }
    }

    public async Task<IResult> GetAllTransactionsByCurrencyIdAndWalletId(int currency_id, int wallet_id)
    {
        try
        {
            List<Transaction> ListTransactions = await _Services.GetAllTransactionsByCurrencyIdAndWalletId(currency_id, wallet_id);
            return Results.Accepted("transactions/wallet/" + wallet_id + "/currency/" + currency_id);
        }
        catch (RecordNotFoundException)
        {

            return Results.BadRequest("There are no transactions with that currency and wallet.");
        }
    }

    public async Task<IResult> CreateTransaction(Transaction transaction)
    {
        try
        {
            return Results.Accepted("/submit/transaction", await _Services.CreateTransaction(transaction));
        }
        catch (RecordNotFoundException)
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
        catch (RecordNotFoundException)
        {
            return Results.BadRequest("Could not update transaction.");
        }
    }
}