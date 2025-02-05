using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.QuestDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultQuestion : ViewComponent
    {
        private readonly IQuestService _questService;
        private readonly IMapper _mapper;

        public _DefaultQuestion(IQuestService questService, IMapper mapper)
        {
            _questService = questService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _questService.TGetListAsync();
            var questList = _mapper.Map<List<ResultQuestDto>>(value);
            return View(questList);
        }
    }
}
