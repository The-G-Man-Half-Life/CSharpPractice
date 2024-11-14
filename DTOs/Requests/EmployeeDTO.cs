using System;
using System.ComponentModel.DataAnnotations;

public class EmployeeDTO
{
    [Required(ErrorMessage = "El nombre es requerido.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El apellido es requerido.")]
    [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "El correo electrónico es requerido.")]
    [MaxLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres.")]
    [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El número de identificación es requerido.")]
    [MaxLength(20, ErrorMessage = "El número de identificación no puede tener más de 20 caracteres.")]
    public string IdentificationNumber { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida.")]
    [MaxLength(255, ErrorMessage = "La contraseña no puede tener más de 255 caracteres.")]
    public string Password { get; set; }
}
