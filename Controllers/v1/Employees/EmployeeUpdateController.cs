using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeC_.DTOs.Requests;
using PracticeC_.Models;
using PracticeC_.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PracticeC_.Controllers.V1.Employees;


[ApiController]
[Route("api/v1/Employees/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Employees")]
public class EmployeeUpdateController : EmployeeController
{
    private new readonly EmployeeServices EmployeeServices;

    public EmployeeUpdateController(EmployeeServices EmployeeServices) : base(EmployeeServices)
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

    [HttpPut("{id}")]
    // [Authorize]
    [SwaggerOperation(Summary = "Crea un nuevo empleado", Description = "Permite al usuario crear un nuevo empleado.")]
    [SwaggerResponse(200, "Empleado creado exitosamente", typeof(Employee))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]

    public async Task<ActionResult> UpdateEmployee([FromRoute]int id,[FromBody]EmployeeDTO EmployeeDTO)
    {
        if (await EmployeeServices.CheckExistence(id) == false)
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
                var FoundEmployee = await EmployeeServices.GetById(id);

                FoundEmployee.Name = EmployeeDTO.Name;
                FoundEmployee.LastName = EmployeeDTO.LastName;
                FoundEmployee.Email = EmployeeDTO.Email;
                FoundEmployee.IdentificationNumber = EmployeeDTO.IdentificationNumber;
                FoundEmployee.Password = EmployeeDTO.Password;

                await EmployeeServices.Update(FoundEmployee);
                return Ok("The Room type was updated succesfully");
            }
            catch (DbUpdateException dbEX)
            {

                throw new Exception("ocurrio un error",dbEX);
            }

        }
    }
}