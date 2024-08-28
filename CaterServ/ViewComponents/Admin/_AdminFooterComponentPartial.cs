using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Admin
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
