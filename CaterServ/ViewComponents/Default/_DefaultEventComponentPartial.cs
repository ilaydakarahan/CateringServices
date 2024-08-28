using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultEventComponentPartial : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IEventCategoryService _eventCategoryService;
        public _DefaultEventComponentPartial(IEventService eventService, IEventCategoryService eventCategoryService)
        {
            _eventService = eventService;
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _eventService.GetEventsAndCategories();
            var categoryList = await _eventCategoryService.GetAllEventCategory();
            ViewBag.categoryList = categoryList;
            return View(values);
        }
    }
}
