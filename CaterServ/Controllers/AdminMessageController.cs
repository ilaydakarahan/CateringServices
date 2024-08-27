using AutoMapper;
using CaterServ.Services.Abstract;
using CaterServ.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMessageService _messageService;

        public AdminMessageController(IMapper mapper, IMessageService messageService)
        {
            _mapper = mapper;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _messageService.GetAllMessages();
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _messageService.DeleteMessage(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DetailMessage(string id)
        {
            var value = await _messageService.GetMessageById(id);
            return View(value);
        }
    }
}
