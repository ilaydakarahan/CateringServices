using AutoMapper;
using CaterServ.Dtos.CheffDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminCheffController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICheffService _cheffService;

        public AdminCheffController(IMapper mapper, ICheffService cheffService)
        {
            _mapper = mapper;
            _cheffService = cheffService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _cheffService.GetAllCheffs();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCheff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCheff(CreateCheffDto createCheffDto)
        {
            await _cheffService.CreateCheff(createCheffDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCheff(string id)
        {
            await _cheffService.DeleteCheff(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCheff(string id)
        {
            var value = await _cheffService.GetCheffById(id);
            var Cheff = _mapper.Map<UpdateCheffDto>(value);
            return View(Cheff);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCheff(UpdateCheffDto updateCheffDto)
        {
            await _cheffService.UpdateCheff(updateCheffDto);
            return RedirectToAction("Index");
        }
    }
}
