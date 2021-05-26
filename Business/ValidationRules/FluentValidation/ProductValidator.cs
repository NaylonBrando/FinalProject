using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        //Kurallar kurucu metod içine yazılır
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("10 liradan yüksek olmalı");//0dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1); //kategori idsi 1 olanların min fiyatı 10 birim

        }
    }
}
