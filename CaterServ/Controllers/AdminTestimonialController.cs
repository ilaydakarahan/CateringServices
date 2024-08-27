using AutoMapper;
using CaterServ.Dtos.TestimonialDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITestimonialService _testimonialService;

        public AdminTestimonialController(IMapper mapper, ITestimonialService TestimonialService)
        {
            _mapper = mapper;
            _testimonialService = TestimonialService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllTestimonials();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.CreateTestimonial(createTestimonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonial(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonailById(id);
            var Testimonial = _mapper.Map<UpdateTestimonialDto>(value);
            return View(Testimonial);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonial(updateTestimonialDto);
            return RedirectToAction("Index");
        }
    }
}
