using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PracticeC_.Repositories.Interfaces;
using PracticeC_.Services;

namespace PracticeC_.Controllers.V1.Room_types;
[ApiController]
[Route("api/V1/Room_types/[controller]")]
[ApiExplorerSettings(GroupName ="v1")]
[Tags("Room_types")]
public class Room_typeController : ControllerBase
{
    protected readonly Room_typeServices Room_typeServices;

    public Room_typeController(Room_typeServices Room_typeServices)
    {
        this.Room_typeServices = Room_typeServices;
    }
}