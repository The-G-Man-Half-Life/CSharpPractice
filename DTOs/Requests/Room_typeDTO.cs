using System.ComponentModel.DataAnnotations;

namespace PracticeC_.DTOs.Requests;
public class Room_typeDTO
{
    [Required(ErrorMessage = "The Name field is required.")]
    [MaxLength(50, ErrorMessage = "The Name field cannot be longer than 50 characters.")]
    public string Name { get; set; }

    [MaxLength(255, ErrorMessage = "The Name field cannot be longer than 255 characters.")]
    public string? Description { get; set; }
}