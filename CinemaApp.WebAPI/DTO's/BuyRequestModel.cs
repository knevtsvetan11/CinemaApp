using System.ComponentModel.DataAnnotations;

namespace CinemaApp.WebAPI.DTO_s;

//DTO/BuyAction
public class BuyRequestModel
{
    [Required]
    public string? cinemaId { get; set; }

    [Required]
    public string? movieId { get; set; }

    [Required]
    // Използваме 'string', защото JavaScript го изпраща като стринг, а ASP.NET Core ще го парсне
    public string? showtime { get; set; }

    [Required]
    [Range(1, 100)] // Добавена е базова валидация
    public int quantity { get; set; }

}
