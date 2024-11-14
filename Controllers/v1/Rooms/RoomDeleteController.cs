using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Rooms;


[ApiController]
[Route("api/v1/Rooms/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Rooms")]
public class RoomDeleteController : RoomController
{
    private new readonly RoomServices RoomServices;

    public RoomDeleteController(RoomServices RoomServices) : base(RoomServices)
    {
        this.RoomServices = RoomServices;
    }

    /// <summary>
    /// Crea un nuevo tipo de cuarto.
    /// </summary>
    /// <param name="EmployeeDTO">El DTO del tipo de cuarto con los datos requeridos.</param>
    /// <returns>Devuelve el nuevo tipo de cuarto creado.</returns>
    /// <response code="200">Devuelve el tipo de cuarto creado.</response>
    /// <response code="400">Si el modelo es nulo o inválido.</response>
    /// 

    [HttpDelete("{id}")]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Room))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<IActionResult> DeleteRoomType([FromRoute] int id)
    {   
        if (await RoomServices.CheckExistence(id) == false)
        {
            return BadRequest("The model can not be found");
        }
        else if (string.IsNullOrWhiteSpace(id.ToString()))
        {
            return BadRequest("You can not leavea a blank space in the request");
        }

        else
        {
            try
            {

                await RoomServices.Delete(id);
                return Ok("The room type was erased");

            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}