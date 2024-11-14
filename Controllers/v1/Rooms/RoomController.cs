using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PracticeC_.Repositories.Interfaces;
using PracticeC_.Services;

namespace PracticeC_.Controllers.V1.Rooms;
[ApiController]
[Route("api/V1/Rooms/[controller]")]
[ApiExplorerSettings(GroupName ="v1")]
[Tags("Rooms")]
public class RoomController : ControllerBase
{
    protected readonly RoomServices RoomServices;

    public RoomController(RoomServices RoomServices)
    {
        this.RoomServices = RoomServices;
    }
}