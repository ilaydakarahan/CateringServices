using AutoMapper;
using CaterServ.Dtos.FeatureDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFeatureService _featureService;

        public AdminFeatureController(IMapper mapper, IFeatureService FeatureService)
        {
            _mapper = mapper;
            _featureService = FeatureService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _featureService.GetAllFeatures();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeature(createFeatureDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeature(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeature(string id)
        {
            var value = await _featureService.GetFeatureById(id);
            var Feature = _mapper.Map<UpdateFeatureDto>(value);
            return View(Feature);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeature(updateFeatureDto);
            return RedirectToAction("Index");
        }
    }
}
