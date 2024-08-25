using AutoMapper;
using CaterServ.Dtos.EventCategoryDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CaterServ.Controllers
{
    public class AdminEventCategoryController : Controller
    {
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IMapper _mapper;

        public AdminEventCategoryController(IEventCategoryService eventCategoryService, IMapper mapper)
        {
            _eventCategoryService = eventCategoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _eventCategoryService.GetAllEventCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEventCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEventCategory(CreateEventCategoryDto eventCategoryDto)
        {
            await _eventCategoryService.CreateEventCategory(eventCategoryDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEventCategory(string id)
        {
            var value = await _eventCategoryService.GetEventCategoryById(id);
            var prop = _mapper.Map<UpdateEventCategoryDto>(value);
            return View(prop);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEventCategory(UpdateEventCategoryDto eventCategoryDto)
        {
            await _eventCategoryService.UpdateEventCategory(eventCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEventCategory(string id)
        {
            await _eventCategoryService.DeleteEventCategory(id);
            return RedirectToAction("Index");
        }
    }
}
