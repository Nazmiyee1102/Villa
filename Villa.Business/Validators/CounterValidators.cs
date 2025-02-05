using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class CounterValidators : AbstractValidator<Counter>
    {
        public CounterValidators()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter girebilirsiniz.");
            RuleFor(x => x.Count).NotEmpty().WithMessage("Değer boş bırakılamaz!");
            RuleFor(x => x.Count).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz.");
            RuleFor(x => x.Count).MinimumLength(1).WithMessage("En az 1 karakter girebilirsiniz.");
        }
    }
}
