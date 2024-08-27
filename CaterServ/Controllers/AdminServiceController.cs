using AutoMapper;
using CaterServ.Dtos.ServiceDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServicesService _serviceValue;

        public AdminServiceController(IMapper mapper, IServicesService ServiceService)
        {
            _mapper = mapper;
            _serviceValue = ServiceService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _serviceValue.GetAllServices();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceValue.CreateService(createServiceDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(string id)
        {
            await _serviceValue.DeleteService(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateService(string id)
        {
            var value = await _serviceValue.GetServiceById(id);
            var Service = _mapper.Map<UpdateServiceDto>(value);
            return View(Service);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceValue.UpdateService(updateServiceDto);
            return RedirectToAction("Index");
        }
    }
}
