using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminFeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
