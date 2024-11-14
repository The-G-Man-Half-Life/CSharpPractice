using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Bookings;


[ApiController]
[Route("api/v1/Bookings/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Bookings")]
public class BookingCreateController : BookingController
{
    private new readonly BookingServices BookingServices;
    private new readonly RoomServices RoomServices;
    private new readonly GuestServices GuestServices;
    private new readonly EmployeeServices EmployeeServices;

    public BookingCreateController(BookingServices BookingServices,RoomServices RoomServices ,GuestServices GuestServices ,EmployeeServices EmployeeServices) : base(BookingServices)
    {
        this.BookingServices = BookingServices;
        this.RoomServices = RoomServices;
        this.GuestServices = GuestServices;
        this.EmployeeServices = EmployeeServices;
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
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Booking))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<IActionResult> CreateNewBooking([FromBody] BookingDTO BookingDTO)
    {
        if (BookingDTO == null)
        {
            return BadRequest("The model can not be null");
        }
        else if (ModelState.IsValid == false)
        {
            return BadRequest("The model is wrong");
        }
        else if (await RoomServices.CheckExistence(BookingDTO.RoomId) == false)
        {
            return BadRequest("The Room does not exist pls try again");
        }
        else if (await GuestServices.CheckExistence(BookingDTO.GuestId) == false)
        {
            return BadRequest("The guest does not exist pls try again");
        }
        else if (await EmployeeServices.CheckExistence(BookingDTO.EmployeeId) == false)
        {
            return BadRequest("The employee does not exist pls try again");
        }
        else if (BookingDTO.StartDate >BookingDTO.EndDate)
        {
            return BadRequest("You can not put a booking date older than the day it has been booked");
        }
        {
            try
            {
                int DifferenceOfDates = (BookingDTO.EndDate - BookingDTO.StartDate).Days;
                
                var Room = await RoomServices.GetById(BookingDTO.RoomId);

                double TotalPrice = DifferenceOfDates * Room.PricePerNight;
                
                var newBooking = new Booking(
                    BookingDTO.StartDate,
                    BookingDTO.EndDate,
                    TotalPrice,
                    BookingDTO.EmployeeId,
                    BookingDTO.GuestId,
                    BookingDTO.RoomId
            );
                await BookingServices.Add(newBooking);
                return Ok(newBooking);

            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}