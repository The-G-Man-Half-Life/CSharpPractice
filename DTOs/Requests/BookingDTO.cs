using System;
using System.ComponentModel.DataAnnotations;

public class BookingDTO
{
    [Required(ErrorMessage = "La fecha de inicio es requerida.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "La fecha de fin es requerida.")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "El ID del empleado es requerido.")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "El ID del huésped es requerido.")]
    public int GuestId { get; set; }

    [Required(ErrorMessage = "El ID de la habitación es requerido.")]
    public int RoomId { get; set; }
}
