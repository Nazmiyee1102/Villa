using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class BannerValidators : AbstractValidator<Banner>
    {
        public BannerValidators()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir adı boş bırakılamaz!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter olmalıdır!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Url boş bırakılamaz!");
        }

        
    }
}
