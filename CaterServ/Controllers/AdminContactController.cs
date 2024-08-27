using AutoMapper;
using CaterServ.Dtos.ContactDtos;
using CaterServ.Services.Abstract;
using CaterServ.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public AdminContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllContact();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateContact(createContactDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateContact(string id)
        {
            var value = await _contactService.GetContactById(id);
            var Contact = _mapper.Map<UpdateContactDto>(value);
            return View(Contact);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContact(updateContactDto);
            return RedirectToAction("Index");
        }
    }
}
