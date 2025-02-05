using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class VideoValidators : AbstractValidator<Video>
    {
        public VideoValidators()
        {
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video Url boş geçilemez");
            RuleFor(x => x.VideoUrl).MaximumLength(200).WithMessage("Video Url en fazla 200 karakter olabilir");
            RuleFor(x => x.VideoUrl).Must(x => x.Contains("https://www.youtube.com/watch?v=")).WithMessage("Video Url youtube linki olmalıdır");
        }
    }
}
