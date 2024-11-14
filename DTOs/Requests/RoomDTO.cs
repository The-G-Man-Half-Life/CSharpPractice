using System;
using System.ComponentModel.DataAnnotations;

public class RoomDTO
{
    [Required(ErrorMessage = "El número del cuarto es requerido.")]
    [MaxLength(10, ErrorMessage = "El número del cuarto no puede tener más de 10 caracteres.")]
    public string RoomNumber { get; set; }

    [Required(ErrorMessage = "El precio por noche es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio por noche debe ser mayor que cero.")]
    public double PricePerNight { get; set; }

    [Required(ErrorMessage = "La disponibilidad es requerida.")]
    public bool Availability { get; set; }

    [Required(ErrorMessage = "La ocupación máxima es requerida.")]
    [Range(1, int.MaxValue, ErrorMessage = "La ocupación máxima debe ser al menos 1.")]
    public byte MaxOccupancyPeople { get; set; }

    [Required(ErrorMessage = "El ID del tipo de cuarto es requerido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID del tipo de cuarto debe ser un valor válido.")]
    public int RoomTypeId { get; set; }
}
