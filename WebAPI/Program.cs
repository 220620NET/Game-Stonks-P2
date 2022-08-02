
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

//----------Services---------------
builder.Services.AddScoped<WalletServices>();
builder.Services.AddScoped<TransactionServices>();

//----------Controllers------------
builder.Services.AddScoped<WalletController>();
builder.Services.AddScoped<TransactionController>();


//------------Swagger--------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


//------------Wallet---------------
app.MapGet("/wallet", (WalletController controller) => controller.GetAllWallets());

app.MapGet("/wallet", (int trainerId, WalletController controller) => controller.GetAllWalletsByUserId((int) trainerId));

app.MapPost("/wallet", ([FromBody] Wallet wallet, WalletController controller) => controller.CreateWallet(wallet));

app.MapPut("/wallet", ([FromBody] Wallet wallet,WalletController controller) => controller.UpdateWallet(wallet));

//-----------Transaction-----------
app.MapGet("/transaction", async (TransactionController controller) => await controller.GetAllTransactions());







app.Run();
