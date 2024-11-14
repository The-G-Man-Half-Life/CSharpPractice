using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Employees;


[ApiController]
[Route("api/v1/Employees/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Employees")]
public class EmployeeGetController : EmployeeController
{
    private new readonly EmployeeServices EmployeeServices;

    public EmployeeGetController(EmployeeServices EmployeeServices) : base(EmployeeServices)
    {
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

    [HttpGet]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Employee))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<ActionResult<IEnumerable<Employee>>> GetAllRoomTypes()
    {
        var Rooms = await EmployeeServices.GetAll();
        if (Rooms.Count() == 0)
        {
            return BadRequest("There are not any Employees");
        }
        else
        {
            try
            {
                return Ok(Rooms);

            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}