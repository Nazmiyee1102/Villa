using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class FeatureValidators : AbstractValidator<Feature>
    {
        public FeatureValidators()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url boş bırakılamaz!");
            RuleFor(x => x.ImageUrl).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz!");
            RuleFor(x => x.ImageUrl).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz!");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("En fazla 100 karakter girebilirsiniz!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Alt Başlık boş bırakılamaz!");
            RuleFor(x => x.SubTitle).MaximumLength(100).WithMessage("En fazla 100 karakter girebilirsiniz!");
            RuleFor(x => x.SubTitle).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.Square).NotEmpty().WithMessage("Metrekare boş bırakılamaz!");
            RuleFor(x => x.Square).MaximumLength(100).WithMessage("En fazla 100 karakter girebilirsiniz!");
            RuleFor(x => x.Square).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.Contract).NotEmpty().WithMessage("Kontrat boş bırakılamaz!");
            RuleFor(x => x.Contract).MaximumLength(100).WithMessage("En fazla 100 karakter girebilirsiniz!");
            RuleFor(x => x.Contract).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.Safety).NotEmpty().WithMessage("Güvenlik boş bırakılamaz!");
            RuleFor(x => x.Safety).MaximumLength(100).WithMessage("En fazla 100 karakter girebilirsiniz!");
            RuleFor(x => x.Safety).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
        }
    }
}
