// using GameStore.Api.Dtos;
using GameStore.Api.Data;
using GameStore.Api.GamesEndpoints;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddGameStoreDbContext();




var app = builder.Build();
app.MapGamesEndpoints();

app.migrateDatabase();
app.Run();
