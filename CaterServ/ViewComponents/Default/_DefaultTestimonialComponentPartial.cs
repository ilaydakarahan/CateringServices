using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _DefaultTestimonialComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _testimonialService.GetAllTestimonials();
            return View(value);
        }
    }
}
