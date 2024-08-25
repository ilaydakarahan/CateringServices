using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _DefaultAboutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _aboutService.GetAllAbouts();
            return View(value);
        }
    }
}
