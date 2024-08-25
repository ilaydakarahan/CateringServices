using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Admin
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
