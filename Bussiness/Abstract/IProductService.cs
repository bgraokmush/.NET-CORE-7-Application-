using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IProductService
    {
        IDataResults<List<Product>> GetAll();
        IDataResults<List<Product>> GetAllByCategoryID(int id);
        IDataResults<List<Product>> GetByUnitByPrice(decimal min, decimal max);

        IDataResults<List<ProductDetailDto>> GetProductDetails();

        IDataResults<Product> GetByID(int productID);
        IResult Add(Product product);
    }
}
