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
public class RoomCreateController : RoomController
{
    private new readonly RoomServices RoomServices;
    private new readonly Room_typeServices Room_typeServices;

    public RoomCreateController(RoomServices RoomServices, Room_typeServices Room_typeServices) : base(RoomServices)
    {
        this.RoomServices = RoomServices;
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

    [HttpPost]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Room))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<IActionResult> CreateNewR([FromBody] RoomDTO RoomDTO)
    {
        if (RoomDTO == null)
        {
            return BadRequest("The model can not be null");
        }
        else if (ModelState.IsValid == false)
        {
            return BadRequest("The model is wrong");
        }
        else if (await Room_typeServices.CheckExistence(RoomDTO.RoomTypeId) == false)
        {
            return BadRequest("The room type does not exist pls try again");
        }
        else
        {
            try
            {
                var newRoom = new Room(
                    RoomDTO.RoomNumber,
                    RoomDTO.PricePerNight,
                    RoomDTO.Availability,
                    RoomDTO.MaxOccupancyPeople,
                    RoomDTO.RoomTypeId
            );
                await RoomServices.Add(newRoom);
                return Ok(newRoom);

            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}