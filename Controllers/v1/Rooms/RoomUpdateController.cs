using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Rooms;


[ApiController]
[Route("api/v1/Rooms/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Rooms")]
public class RoomUpdateController : RoomController
{
    private new readonly RoomServices RoomServices;
    private new readonly Room_typeServices Room_typeServices;

    public RoomUpdateController(RoomServices RoomServices, Room_typeServices Room_typeServices) : base(RoomServices)
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

    [HttpPut("{id}")]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Room))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<ActionResult> UpdateRoom([FromRoute]int id,[FromBody]RoomDTO RoomDTO)
    {
        if (await RoomServices.CheckExistence(id) == false)
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
        else if (await Room_typeServices.CheckExistence(RoomDTO.RoomTypeId) == false)
        {
            return BadRequest("The room type does not exist in the database");
        }
        else
        {
            try
            {
                var FoundRoom = await RoomServices.GetById(id);

                FoundRoom.RoomNumber = RoomDTO.RoomNumber;
                FoundRoom.PricePerNight = RoomDTO.PricePerNight;
                FoundRoom.Availability = RoomDTO.Availability;
                FoundRoom.MaxOccupancyPeople = RoomDTO.MaxOccupancyPeople;
                FoundRoom.RoomTypeId = RoomDTO.RoomTypeId;
                await RoomServices.Update(FoundRoom);
                return Ok("The Room type was updated succesfully");
            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}