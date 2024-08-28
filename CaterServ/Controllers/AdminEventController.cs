using AutoMapper;
using CaterServ.Dtos.EventDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServ.Controllers
{
    public class AdminEventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;
        private readonly IEventCategoryService _eventCategoryService;

        public AdminEventController(IMapper mapper, IEventService eventService, IEventCategoryService eventCategoryService)
        {
            _mapper = mapper;
            _eventService = eventService;
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _eventService.GetEventsAndCategories();  
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEvent()
        {
            var value = await _eventCategoryService.GetAllEventCategory();  //Event kategorilerini listeledik.Dropdown gibi.

            List<SelectListItem> listItems = (from x in value
                                              select new SelectListItem
                                              {
                                                  Text = x.EventCategoryName,
                                                  Value = x.EventCategoryId.ToString()
                                              }).ToList();
            ViewBag.EventCategoryList = listItems;       //Liste türünde getirdik. adını viewbag ile taşıdık.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            await _eventService.CreateEvent(createEventDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _eventService.DeleteEvent(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEvent(string id)
        {
            var value = await _eventService.GetEventById(id);
            var prop = _mapper.Map<UpdateEventDto>(value);

            var list = await _eventCategoryService.GetAllEventCategory();

            List<SelectListItem> categoryList = (from x in list
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EventCategoryName,
                                                     Value = x.EventCategoryId.ToString()
                                                 }).ToList();
            ViewBag.EventCategoryList = categoryList;
            return View(prop);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            await _eventService.UpdateEvent(updateEventDto);
            return RedirectToAction("Index");
        }
    }
}
