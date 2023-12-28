using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior : AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş olamaz");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori boş olamaz");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalı");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Ürün birimi boş olamaz");
            RuleFor(p => p.ProductName).Length(2, 20).WithMessage("Ürün ismi 2 ile 20 karakter arasında olmalı");
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1).WithMessage("Kategori 1 ise fiyat 20'den büyük olmalı");
            // RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün ismi A ile başlamalı"); // Kendi kuralımızı yazdık
        }


    }
}
