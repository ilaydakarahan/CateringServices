using CaterServ.Dtos.MessageDtos;
using CaterServ.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServ.Controllers
{
    public class DefaultContactController : Controller
    {
        private readonly IMessageService _messageService;

        public DefaultContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddMessage(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessage(createMessageDto);
            return RedirectToAction("Index");
        }
    }
}
