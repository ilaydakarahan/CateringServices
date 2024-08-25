using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
