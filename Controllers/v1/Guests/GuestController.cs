using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PracticeC_.Repositories.Interfaces;
using PracticeC_.Services;

namespace PracticeC_.Controllers.V1.Guests;
[ApiController]
[Route("api/V1/Guests/[controller]")]
[ApiExplorerSettings(GroupName ="v1")]
[Tags("Guests")]
public class GuestController : ControllerBase
{
    protected readonly GuestServices GuestServices;

    public GuestController(GuestServices GuestServices)
    {
        this.GuestServices = GuestServices;
    }
}