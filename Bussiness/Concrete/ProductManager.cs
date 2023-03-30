using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes

            _ProductDal.Add(product);
            return new Result(true, $" {product.ProductName} - {Messages.ProductAdded}");
        }

        public IDataResults<List<Product>> GetAll()
        {
            //business codes
            if (_ProductDal.GetAll != null)
            {
                return new DataResultSuccess<List<Product>>(
                    _ProductDal.GetAll(),
                    Messages.SuccessGetAll);
            }
            else
            {
                return new DataResultError<List<Product>>(Messages.ProductListNull);
            }

        }

        public IDataResults<List<Product>> GetAllByCategoryID(int id)
        {
            return new DataResultSuccess<List<Product>>(
                _ProductDal.GetAll(p => p.CategoryID == id));
        }

        public IDataResults<Product> GetByID(int productID)
        {
            return new DataResultSuccess<Product>(
                _ProductDal.Get(p => p.ProductID == productID));
        }

        public IDataResults<List<Product>> GetByUnitByPrice(decimal min, decimal max)
        {
            if (min < max && min > 0)
            {
                return new DataResultSuccess<List<Product>>(
                _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
            }
            else
            {
                return new DataResultError<List<Product>>(Messages.invalidValue);
            }
        }

        public IDataResults<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataResultSuccess<List<ProductDetailDto>>(
                _ProductDal.GetProductDetails(),
                Messages.detailGetSuccess);
        }


    }
}
