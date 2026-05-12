using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;
public static  class DataExtentions

{
    
    
    public static void migrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<GameStoreContex>();
        db.Database.Migrate();
    }

    public static void AddGameStoreDbContext(this WebApplicationBuilder builder)
    {
        
        var connString= builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=GameStore.db";     

         builder.Services.AddSqlite<GameStoreContex>(connString,optionsAction:Options =>
         Options.UseSeeding((context, _) =>
{
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Set<Genre>().AddRange(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Adventure" },
            new Genre { Id = 3, Name = "RPG" },
            new Genre { Id = 4, Name = "Strategy" },
            new Genre { Id = 5, Name = "Sports" }
        );
        context.SaveChanges();
    }
}    ));
    }
}
// 2h24