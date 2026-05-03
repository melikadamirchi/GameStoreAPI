using System.ComponentModel.DataAnnotations;

public record CreateGameDto(
    [Required][StringLength (50)] string Name,
    [Required] string Description,
    [Required][Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")] decimal Price
);