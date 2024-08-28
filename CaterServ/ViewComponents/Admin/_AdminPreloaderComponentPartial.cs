using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Admin
{
    public class _AdminPreloaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
