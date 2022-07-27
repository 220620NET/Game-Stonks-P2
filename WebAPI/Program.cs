using Services;
using CustomExceptions;
using DataAccess;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});


builder.Services.AddDbContext<PokeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StonkDB")));


var app = builder.Build();

app.Run();
