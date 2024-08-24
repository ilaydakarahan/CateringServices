using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.UILayout
{
    public class _UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
