using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class DefaultProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
