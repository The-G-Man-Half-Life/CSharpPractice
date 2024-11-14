using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PracticeC_.Repositories.Interfaces;
using PracticeC_.Services;

namespace PracticeC_.Controllers.V1.Employees;
[ApiController]
[Route("api/V1/Employees/[controller]")]
[ApiExplorerSettings(GroupName ="v1")]
[Tags("Employees")]
public class EmployeeController : ControllerBase
{
    protected readonly EmployeeServices EmployeeServices;

    public EmployeeController(EmployeeServices EmployeeServices)
    {
        this.EmployeeServices = EmployeeServices;
    }
}