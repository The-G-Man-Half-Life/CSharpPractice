using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Guests;


[ApiController]
[Route("api/v1/Guests/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Guests")]
public class GuestUpdateController : GuestController
{
    private new readonly GuestServices GuestServices;

    public GuestUpdateController(GuestServices GuestServices) : base(GuestServices)
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

    [HttpPut("{id}")]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Guest))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<ActionResult> UpdateGuest([FromRoute]int id,[FromBody]GuestDTO GuestDTO)
    {
        if (await GuestServices.CheckExistence(id) == false)
        {
            return BadRequest("The model could not be sent");
        }
        else if (ModelState.IsNullOrEmpty() == true)
        {
            return BadRequest("You can not submit a blank model");
        }
        else if (ModelState.IsValid == false)
        {
            return BadRequest("You can not upload an incorrect model");
        }
        else
        {
            try
            {
                var FoundGuest = await GuestServices.GetById(id);

                FoundGuest.Name = GuestDTO.Name;
                FoundGuest.LastName = GuestDTO.LastName;
                FoundGuest.Email = GuestDTO.Email;
                FoundGuest.IdentificationNumber = GuestDTO.IdentificationNumber;
                FoundGuest.PhoneNumber = GuestDTO.PhoneNumber;
                FoundGuest.Birthdate = GuestDTO.Birthdate;
                await GuestServices.Update(FoundGuest);
                return Ok("The Room type was updated succesfully");
            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}