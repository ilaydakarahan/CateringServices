using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.ViewComponents.Default
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultFeatureComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _featureService.GetAllFeatures();
            return View(value);
        }
    }
}
