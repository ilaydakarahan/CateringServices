using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.UILayout
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
  
}
