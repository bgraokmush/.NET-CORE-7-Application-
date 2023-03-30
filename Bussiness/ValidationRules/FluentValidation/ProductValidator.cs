using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalı.");
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş olamaz");
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");

            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Ürün fiyatı boş olamaz.");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz.");
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A") || arg.StartsWith("a") ? true : false;
        }
    }
}
