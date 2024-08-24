using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
