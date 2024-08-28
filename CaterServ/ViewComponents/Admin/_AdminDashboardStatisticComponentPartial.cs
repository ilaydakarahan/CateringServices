using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Admin
{
    public class _AdminDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _AdminDashboardStatisticComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _dashboardService.GetDashboardAll();
            return View(values);
        }
    }
}
