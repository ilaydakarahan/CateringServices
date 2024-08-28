using AutoMapper;
using CaterServ.Dtos.BookingDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServ.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IEventCategoryService _eventCategoryService;

        public AdminBookingController(IBookingService bookingService, IMapper mapper, IEventCategoryService eventCategoryService)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bookingService.GetAllBookings();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            var value = await _eventCategoryService.GetAllEventCategory();  //Yeni rezervasyon eklerken kategoriyi listeden seçtiriyoruz.

            List<SelectListItem> categoryList = (from x in value
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EventCategoryName,
                                                     Value = x.EventCategoryId
                                                 }).ToList();
            ViewBag.CategoryList = categoryList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBooking(createBookingDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBooking(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(string id)
        {
            var value = await _bookingService.GetBookingById(id);
            var prop = _mapper.Map<UpdateBookingDto>(value);

            var values = await _eventCategoryService.GetAllEventCategory();
            List<SelectListItem> categoryList = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EventCategoryName,
                                                     Value = x.EventCategoryId
                                                 }).ToList();
            ViewBag.CategoryList = categoryList;
            return View(prop);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            await _bookingService.UpdateBooking(updateBookingDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SearchBooking(string nameSurname)
        {
            var value = await _bookingService.SearchBooking(nameSurname);
            TempData["allbooking"] = "true";
            return View("Index", value);
        }
    }
}
