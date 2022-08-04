
using CustomExceptions;
using DataAccess;
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers;




var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

//--------- Data Access------------
builder.Services.AddDbContext<StonksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StonkDB")));
builder.Services.AddScoped<IWalletDAO, WalletRepository>();
builder.Services.AddScoped<ITransactionDAO, TransactionRepository>();
builder.Services.AddScoped<IUserDAO, UserRepository>();

//----------Services---------------
builder.Services.AddTransient<WalletServices>();
builder.Services.AddTransient<TransactionServices>();
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<AuthServices>();

//----------Controllers------------
builder.Services.AddScoped<WalletController>();
builder.Services.AddScoped<TransactionController>();
builder.Services.AddScoped<UserController>();

//------------Swagger--------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//------------Auth-----------------
app.MapPost("/register", (User user, AuthController controller) =>controller.Register(user));

app.MapPost("/login", (User user, AuthController controller) => controller.Login(user));

//------------Wallet---------------
app.MapGet("/wallet", async (WalletController controller) => await controller.GetAllWallets());

app.MapGet("/wallet/user/{ID}", async (int user_id, WalletController controller) => await controller.GetAllWalletsByUserId((int) user_id));

app.MapPost("/submit/wallet", async ([FromBody] Wallet wallet, WalletController controller) => await controller.CreateWallet(wallet));

app.MapPut("/update/wallet", async ([FromBody] Wallet wallet,WalletController controller) => await controller.UpdateWallet(wallet));

//-----------Transaction-----------
app.MapGet("/transaction", async (TransactionController controller) => await controller.GetAllTransactions());

app.MapPost("/submit/transaction", (Transaction newTransaction, TransactionController controller) => controller.CreateTransaction(newTransaction));

app.MapPut("/update/ticket", (Transaction newTransaction, TransactionController controller) => controller.UpdateTransaction(newTransaction));

app.MapGet("/transaction/wallet/{ID}", (int ID, TransactionController controller) => controller.GetAllTransactionsByWalletId(ID));

app.MapGet("/transaction/currency/{ID}", (int ID, TransactionController controller) => controller.GetAllTransactionsByWalletId(ID));

//-----------Transaction-----------
app.MapGet("/Currency", async (CurrencyController controller) => await controller.GetAllCurrencies());

app.MapGet("/Currency/{ID}", async (int ID, CurrencyController controller) => await controller.GetCurrencyById(ID));

app.MapGet("/Currency/{Symbol}", async (string symbol, CurrencyController controller) => await controller.GetCurrencyBySymbol(symbol));

app.MapPost("/submit/Currency", async (Currency currency, CurrencyController controller) => await controller.CreateCurrency(currency));

app.MapPut("/update/Currrency", async (Currency currency, CurrencyController controller) => await controller.UpdateCurrency(currency));

//------------User-------------
app.MapGet("/user", async (UserController controller) =>await controller.GetAllUsers());

app.MapGet("/user/id/{id}", async (int id, UserController controller) =>await controller.GetUserById(id));

app.MapGet("/user/email/{email}", async (string email, UserController controller) =>await controller.GetUserByEmail(email));

app.MapPost("/create/User", async (User user, UserController controller) => await controller.CreateUser(user));

app.MapPut("/update/User", async (User user, UserController controller) => await controller.UpdateUser(user));

app.Run();
