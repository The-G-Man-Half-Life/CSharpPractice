using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Room_types;


[ApiController]
[Route("api/v1/Room_types/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Room_types")]
public class Room_typeUpdateController : Room_typeController
{
    private new readonly Room_typeServices Room_typeServices;

    public Room_typeUpdateController(Room_typeServices Room_typeServices) : base(Room_typeServices)
    {
        this.Room_typeServices = Room_typeServices;
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
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Room_type))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<ActionResult> UpdateRoomTypes([FromRoute]int id,[FromBody]Room_typeDTO Room_typeDTO)
    {
        if (await Room_typeServices.CheckExistence(id) == false)
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
                var FoundRoom_type = await Room_typeServices.GetById(id);

                FoundRoom_type.Name = Room_typeDTO.Name;
                FoundRoom_type.Description = Room_typeDTO.Description;
                await Room_typeServices.Update(FoundRoom_type);
                return Ok("The Room type was updated succesfully");
            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}