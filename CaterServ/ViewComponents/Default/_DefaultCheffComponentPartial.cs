using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultCheffComponentPartial : ViewComponent
    {
        private readonly ICheffService _cheffService;

        public _DefaultCheffComponentPartial(ICheffService cheffService)
        {
            _cheffService = cheffService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _cheffService.GetAllCheffs();
            return View(values);
        }
    }
}
