using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultBookingComponentPartial : ViewComponent
    {
        private readonly IEventCategoryService _eventCategoryService;
        public _DefaultBookingComponentPartial(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
