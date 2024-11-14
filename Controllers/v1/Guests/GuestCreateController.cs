using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Guests;


[ApiController]
[Route("api/v1/Guests/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Guests")]
public class GuestCreateController : GuestController
{
    private new readonly GuestServices GuestServices;

    public GuestCreateController(GuestServices GuestServices) : base(GuestServices)
    {
        this.GuestServices = GuestServices;
    }

    /// <summary>
    /// Crea un nuevo tipo de cuarto.
    /// </summary>
    /// <param name="EmployeeDTO">El DTO del tipo de cuarto con los datos requeridos.</param>
    /// <returns>Devuelve el nuevo tipo de cuarto creado.</returns>
    /// <response code="200">Devuelve el tipo de cuarto creado.</response>
    /// <response code="400">Si el modelo es nulo o inválido.</response>
    /// 

    [HttpPost]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Guest))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<IActionResult> CreateNewGuest([FromBody] GuestDTO GuestDTO)
    {
        if (GuestDTO == null)
        {
            return BadRequest("The model can not be null");
        }
        else if (ModelState.IsValid == false)
        {
            return BadRequest("The model is wrong");
        }
        else
        {
            try
            {
                var newGuest = new Guest(
                    GuestDTO.Name,
                    GuestDTO.LastName,
                    GuestDTO.Email,
                    GuestDTO.IdentificationNumber,
                    GuestDTO.PhoneNumber,
                    GuestDTO.Birthdate
            );
                await GuestServices.Add(newGuest);
                return Ok(newGuest);

            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}