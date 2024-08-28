using AutoMapper;
using CaterServ.Dtos.StatisticDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminStatisticController : Controller
    {
        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;

        public AdminStatisticController(IStatisticService StatisticService, IMapper mapper)
        {
            _statisticService = StatisticService;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var values = await _statisticService.GetAllStatistic();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateStatistic()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStatistic(CreateStatisticDto createStatisticDto)
        {
            await _statisticService.CreateStatistic(createStatisticDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatistic(string id)
        {
            var value = await _statisticService.GetStatisticById(id);
            var mappedValue = _mapper.Map<UpdateStatisticDto>(value);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatistic(UpdateStatisticDto updateStatisticDto)
        {
            await _statisticService.UpdateStatistic(updateStatisticDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteStatistic(string id)
        {
            await _statisticService.DeleteStatistic(id);
            return RedirectToAction("Index");
        }
    }
}
