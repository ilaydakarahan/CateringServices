using CaterServ.Dtos.BookingDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IBookingService _bookingService;

        public DefaultController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBooking(createBookingDto);
            return RedirectToAction("Index");
        }
    }
}
