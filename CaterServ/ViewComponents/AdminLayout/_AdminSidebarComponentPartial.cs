using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Admin
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
