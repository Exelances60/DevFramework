
using DevFramework.core.CroosCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManger : IProductService
    {
        private IProductDal _productDal;
      //  private ProductValidatior _validationRules; bu şekilde de olabilir 2 kere newlemek yerine bir kere newleyip kullanmak için dependency injection kullanıyoruz.

        public ProductManger(IProductDal productDal, ProductValidatior validationRules)
        {
            _productDal = productDal;
         //    _validationRules = validationRules; bu şekilde de olabilir 2 kere newlemek yerine bir kere newleyip kullanmak için dependency injection kullanıyoruz.
        }
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        [FluentValidate(typeof(ProductValidatior))]
        public Product Add(Product product)
        {
              
            ValidatiorTool.FluentValidate(new ProductValidatior(), product);
            return _productDal.Add(product);
        }
        [FluentValidate(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            ValidatiorTool.FluentValidate(new ProductValidatior(), product);
            return _productDal.Update(product);
        }
    }
}
