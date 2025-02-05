using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Dto.Dtos.VideoDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;

        public VideoController(IVideoService videoService, IMapper mapper)
        {
            _videoService = videoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _videoService.TGetListAsync();
            var videoList = _mapper.Map<List<ResultVideoDto>>(values);
            return View(videoList);
        }

        public async Task<IActionResult> DeleteVideo(ObjectId id)
        {
            await _videoService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideoDto)
        {
            ModelState.Clear();
            var newVideo = _mapper.Map<Video>(createVideoDto);
            var validator = new VideoValidators();
            var result = validator.Validate(newVideo);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _videoService.TCreateAsync(newVideo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateVideo(ObjectId id)
        {
            var video = await _videoService.TGetByIdAsync(id);
            var videoDto = _mapper.Map<UpdateVideoDto>(video);
            return View(videoDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto updateVideoDto)
        {
            var video = _mapper.Map<Video>(updateVideoDto);
            await _videoService.TUpdateAsync(video);
            return RedirectToAction("Index");
        }
    }
}
