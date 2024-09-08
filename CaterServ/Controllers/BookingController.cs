using CaterServ.Dtos.BookingDtos;
using CaterServ.Services.Abstract;
using CaterServ.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServ.Controllers
{
    public class BookingController : Controller
    {
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IBookingService _bookingService;

        public BookingController(IEventCategoryService eventCategoryService, IBookingService bookingService)
        {
            _eventCategoryService = eventCategoryService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _eventCategoryService.GetAllEventCategory();
            List<SelectListItem> result = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.EventCategoryName,
                                               Value = x.EventCategoryId
                                           }).ToList();
            ViewBag.eventcategory = result;
            return View();
        }

        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBooking(createBookingDto);
            return RedirectToAction("Index","Default");
        }
    }
}
