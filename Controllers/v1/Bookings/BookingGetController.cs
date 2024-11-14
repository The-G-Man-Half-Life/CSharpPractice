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
public class BookingGetController : BookingController
{
    private new readonly BookingServices BookingServices;

    public BookingGetController(BookingServices BookingServices) : base(BookingServices)
    {
        this.BookingServices = BookingServices;
    }

    /// <summary>
    /// Crea un nuevo tipo de cuarto.
    /// </summary>
    /// <param name="EmployeeDTO">El DTO del tipo de cuarto con los datos requeridos.</param>
    /// <returns>Devuelve el nuevo tipo de cuarto creado.</returns>
    /// <response code="200">Devuelve el tipo de cuarto creado.</response>
    /// <response code="400">Si el modelo es nulo o inválido.</response>
    /// 

    [HttpGet]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Booking))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<ActionResult<IEnumerable<Booking>>> GetAllBookingTypes()
    {
        var Bookings = await BookingServices.GetAll();
        if (Bookings.Count() == 0)
        {
            return BadRequest("There are not any Bookings");
        }
        else
        {
            try
            {
                return Ok(Bookings);

            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}