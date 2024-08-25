using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class DefaultContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
