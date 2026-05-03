using Microsoft.EntityFrameworkCore;
using GameStore.Api.Models;

namespace GameStore.Api.Data;

public class GameStoreContex(DbContextOptions<GameStoreContex> options): DbContext(options)
{
    public DbSet<Game> Games =>Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}
