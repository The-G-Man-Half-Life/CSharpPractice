using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using PracticeC_.Repositories.Interfaces;
using PracticeC_.Services;

namespace PracticeC_.Controllers.V1.Bookings;
[ApiController]
[Route("api/V1/Bookings/[controller]")]
[ApiExplorerSettings(GroupName ="v1")]
[Tags("Bookings")]
public class BookingController : ControllerBase
{
    protected readonly BookingServices BookingServices;

    public BookingController(BookingServices BookingServices)
    {
        this.BookingServices = BookingServices;
    }
}