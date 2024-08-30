using AutoMapper;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class DefaultEventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IMapper _mapper;

        public DefaultEventController(IEventService eventService, IEventCategoryService eventCategoryService, IMapper mapper)
        {
            _eventService = eventService;
            _eventCategoryService = eventCategoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _eventService.GetEventsAndCategories();
            var categoryList = await _eventCategoryService.GetAllEventCategory();

            ViewBag.CategoryList = categoryList;
            return View(values);
        }
    }
}
