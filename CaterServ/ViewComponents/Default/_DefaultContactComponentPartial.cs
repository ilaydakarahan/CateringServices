using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _DefaultContactComponentPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _contactService.GetAllContact();
            return View(value);
        }
    }
}
