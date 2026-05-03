namespace GameStore.Api.GamesEndpoints;


public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";
    
 private static readonly List<GameDto> games=[
    new(1,"strret fighter1","fighting1",12m),
    new(2,"strret fighter2","fighting2",13m),
    new(3,"strret fighter3","fighting3",14m),
    
 ];
// app.MapGet("/Games", () => games);



public static void MapGamesEndpoints(this WebApplication app){

var group=app.MapGroup("/Games");
// MAPGATE
group.MapGet("/{id}", (int id) =>
{
   var game=  games.Find(game => game.Id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);

}).WithName(GetGameEndpointName);


// MAPPOST
group.MapPost("/", (GameDto game) =>
{
    // if (string.IsNullOrEmpty(game.Name) || string.IsNullOrEmpty(game.Description) || game.Price <= 0)
    // {
    //     return Results.BadRequest("Namme is required, description is required and price must be greater than 0.");
    // }

    games.Add(game);
    return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);
});

// MAPPUT
group.MapPut("/{id}", (int id, GameDto updatedGame) =>
{
    var game = games.FindIndex(g => g.Id == id);

    if (game == -1){
        return Results.NotFound();
    }

games[game] = new GameDto(id, updatedGame.Name, updatedGame.Description, updatedGame.Price
);
    return Results.NoContent();
});


// MAPDELETE
group.MapDelete("/{id}", (int id) =>
{
    var game = games.FindIndex(g => g.Id == id);
    if (game == -1)
    {
        return Results.NotFound();
    }
    games.RemoveAt(game);
    return Results.NoContent();
});
}}