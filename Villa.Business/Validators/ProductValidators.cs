using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ProductValidators : AbstractValidator<Product>
    {
        public ProductValidators()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Url boş geçilemez");
            RuleFor(x => x.ImageUrl).MaximumLength(50).WithMessage("Resim Url 50 karakterden fazla olamaz");
            RuleFor(x => x.ImageUrl).MinimumLength(5).WithMessage("Resim Url 5 karakterden az olamaz");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Kategori boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ürün başlığı boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Ürün başlığı 50 karakterden fazla olamaz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Ürün başlığı 5 karakterden az olamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
            RuleFor(x => x.Price).MaximumLength(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır");
            RuleFor(x => x.BedroomCount).NotEmpty().WithMessage("Yatak odası sayısı boş geçilemez");
            RuleFor(x => x.BedroomCount).GreaterThan(0).WithMessage("Yatak odası sayısı 0'dan büyük olmalıdır");
            RuleFor(x => x.BathroomCount).NotEmpty().WithMessage("Banyo sayısı boş geçilemez");
            RuleFor(x => x.BathroomCount).GreaterThan(0).WithMessage("Banyo sayısı 0'dan büyük olmalıdır");
            RuleFor(x => x.Area).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.Area).GreaterThan(0).WithMessage("Alan 0'dan büyük olmalıdır");
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Kat boş geçilemez");
            RuleFor(x => x.Floor).GreaterThan(0).WithMessage("Kat 0'dan büyük olmalıdır");
            RuleFor(x => x.ParkingCount).NotEmpty().WithMessage("Park yeri sayısı boş geçilemez");
            RuleFor(x => x.ParkingCount).GreaterThan(0).WithMessage("Park yeri sayısı 0'dan büyük olmalıdır");
        }
    }
}
