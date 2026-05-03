// using GameStore.Api.Dtos;
using GameStore.Api.Data;
using GameStore.Api.GamesEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();



var connString= "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContex>(connString);

var app = builder.Build();
app.MapGamesEndpoints();

app.Run();
