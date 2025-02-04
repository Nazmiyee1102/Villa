using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Dto.Dtos.QuestDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class QuestController : Controller
    {
        private readonly IQuestService _questService;
        private readonly IMapper _mapper;

        public QuestController(IQuestService questService, IMapper mapper)
        {
            _questService = questService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _questService.TGetListAsync();
            var questList = _mapper.Map<List<ResultQuestDto>>(values);
            return View(questList);
        }

        public async Task<IActionResult> DeleteQuest(ObjectId id)
        {
            await _questService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateQuest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuest(CreateQuestDto createQuestDto)
        {
            var newQuest = _mapper.Map<Quest>(createQuestDto);
            await _questService.TCreateAsync(newQuest);
            return RedirectToAction("Index");
        }
    }
}
