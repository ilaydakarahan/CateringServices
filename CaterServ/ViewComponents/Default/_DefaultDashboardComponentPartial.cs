using CaterServ.Services.Abstract;
using CaterServ.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultDashboardComponentPartial : ViewComponent
    {
        private readonly IStatisticService _statisticService;

        public _DefaultDashboardComponentPartial(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value =await  _statisticService.GetAllStatistic();
            return View(value);
        }
    }
}
