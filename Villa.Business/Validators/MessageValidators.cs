using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class MessageValidators : AbstractValidator<Message>
    {
        public MessageValidators()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş geçilemez");
            RuleFor(x => x.MessageContent).MaximumLength(500).WithMessage("Mesaj içeriği 500 karakterden fazla olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kişi adı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(10).WithMessage("Kişi 10 karakterden fazla olamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kişi adı 3 karakterden az olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta boş geçilemez");
            RuleFor(x => x.MessageDate).NotEmpty().WithMessage("Mesaj tarihi boş geçilemez");
            RuleFor(x => x.MessageDate).LessThan(DateTime.Now).WithMessage("Mesaj tarihi bugünden büyük olamaz");
            RuleFor(x => x.MessageDate).GreaterThan(DateTime.Now.AddYears(-1)).WithMessage("Mesaj tarihi 1 yıldan eski olamaz");
        }
    }
}
