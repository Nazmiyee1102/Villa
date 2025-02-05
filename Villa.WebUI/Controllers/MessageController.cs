using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Entity.Entities;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Business.Validators;

namespace Villa.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _messageService.TGetListAsync();
            var messageList = _mapper.Map<List<ResultMessageDto>>(values);
            return View(messageList);
        }

        public async Task<IActionResult> DeleteMessage(ObjectId id)
        {
            await _messageService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            ModelState.Clear();
            var newMessage = _mapper.Map<Message>(createMessageDto);
            var validator = new MessageValidators();
            var result = validator.Validate(newMessage);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _messageService.TCreateAsync(newMessage);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MessageDetails(ObjectId id)
        {
            var message = await _messageService.TGetByIdAsync(id);
            var messageValue = _mapper.Map<ResultMessageDto>(message);
            return View(messageValue);
        }

        
    }
}
