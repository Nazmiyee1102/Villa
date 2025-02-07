using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class DealValidators : AbstractValidator<Deal>
    {
        public DealValidators()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("İlan türü boş bırakılamaz!");
            RuleFor(x => x.Type).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz!");
            RuleFor(x => x.Type).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url boş bırakılamaz!");
            RuleFor(x => x.ImageUrl).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz!");
            RuleFor(x => x.ImageUrl).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz!");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz!");
            RuleFor(x => x.Square).NotEmpty().WithMessage("Metrekare boş bırakılamaz!");
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Kat sayısı boş olamaz!");
            RuleFor(x => x.Floor).MinimumLength(0).WithMessage("Kat sayısı 0'dan büyük olmalıdır!");
            RuleFor(x => x.RoomCount).GreaterThan(0).WithMessage("Oda sayısı 0'dan büyük olmalıdır!");
            RuleFor(x => x.RoomCount).NotEmpty().WithMessage("Oda sayısı boş bırakılamaz!");
            RuleFor(x => x.PaymentType).NotEmpty().WithMessage("Ödeme türü boş bırkılamaz!");
            RuleFor(x => x.PaymentType).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz!");
            RuleFor(x => x.PaymentType).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz!");
        }
    }
}
