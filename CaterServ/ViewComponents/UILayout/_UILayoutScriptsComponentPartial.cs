using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.UILayout
{
    public class _UILayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
