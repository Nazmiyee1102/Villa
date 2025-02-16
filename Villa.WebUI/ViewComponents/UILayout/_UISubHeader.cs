﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.SubHeaderDtos;

namespace Villa.WebUI.ViewComponents.UILayout
{
    public class _UISubHeader : ViewComponent
    {
        private readonly ISubHeaderService _subHeaderService;
        private readonly IMapper _mapper;

        public _UISubHeader(ISubHeaderService subHeaderService, IMapper mapper)
        {
            _subHeaderService = subHeaderService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subHeader = await _subHeaderService.TGetListAsync();
            var subHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(subHeader);
            return View(subHeaderList);
        }
    }
}
