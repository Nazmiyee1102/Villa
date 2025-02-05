using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ContactValidators : AbstractValidator<Contact>
    {
        public ContactValidators()
        {
            RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Harita Url boş bırakılamaz!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş bırakılamaz!");
            RuleFor(x => x.Phone).GetHashCode();
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresini doğru girmelisiniz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş bırakılamaz!");
        }
    }
}
