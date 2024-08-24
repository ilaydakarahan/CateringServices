using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
