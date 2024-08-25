using AutoMapper;
using CaterServ.Dtos.AboutDtos;
using CaterServ.Services.Abstract;
using CaterServ.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAboutService _aboutService;

        public AdminAboutController(IMapper mapper, IAboutService aboutService)
        {
            _mapper = mapper;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAbouts();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAbout(createAboutDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAbout(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAbout(string id)
        {
            var value = await _aboutService.GetAboutById(id);
            var About = _mapper.Map<UpdateAboutDto>(value);
            return View(About);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAbout(updateAboutDto);
            return RedirectToAction("Index");
        }
    }
}
