using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.UILayout
{
    public class _UILayoutSpinnerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
