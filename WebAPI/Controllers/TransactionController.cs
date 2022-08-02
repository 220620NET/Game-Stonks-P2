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
            List<Transaction> ListTickets = await _Services.GetAllTransactions();
            return Results.Accepted("/ticket", ListTickets);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound("There are no users");
        }
    }
}