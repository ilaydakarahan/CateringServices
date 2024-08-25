using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultServiceComponentPartial : ViewComponent
    {
        private readonly IServicesService _serviceService;

        public _DefaultServiceComponentPartial(IServicesService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _serviceService.GetAllServices();
            return View(value);
        }
    }
}
