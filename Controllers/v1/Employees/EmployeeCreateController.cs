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
public class EmployeeCreateController : EmployeeController
{
    private new readonly EmployeeServices EmployeeServices;

    public EmployeeCreateController(EmployeeServices EmployeeServices) : base(EmployeeServices)
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

    [HttpPost]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Employee))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<IActionResult> CreateNewEmployee([FromBody] EmployeeDTO EmployeeDTO)
    {
        if (EmployeeDTO == null)
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
                var newEmployee = new Employee(
                    EmployeeDTO.Name,
                    EmployeeDTO.LastName,
                    EmployeeDTO.Email,
                    EmployeeDTO.IdentificationNumber,
                    EmployeeDTO.Password
            );
                await EmployeeServices.Add(newEmployee);
                return Ok(newEmployee);

            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}