using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
