using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal 
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle, SQL Server, MongoDb   
            _products = new List<Product>
            {
                new Product {ProductID = 1,CategoryID = 1,ProductName  = "Bardak",UnitPrice = 15,UnitsInStock = 15},
                new Product {ProductID = 2,CategoryID = 1,ProductName  = "Kupa",UnitPrice = 45,UnitsInStock = 40},
                new Product {ProductID = 3,CategoryID = 1,ProductName  = "Çay Bardağı",UnitPrice = 20,UnitsInStock = 20},
                new Product {ProductID = 4,CategoryID = 1,ProductName  = "Plastik Bardak",UnitPrice = 5,UnitsInStock = 250},
                new Product {ProductID = 5,CategoryID = 1,ProductName  = "Kahve Bardağı",UnitPrice = 75,UnitsInStock = 100},

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
           
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryID)
        {   // where (sql deki gibi) şarta uyan tüm elemanları liste haline getirip döndürür
            return _products.Where(p => p.CategoryID == categoryID).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
          
            productToUpdate.ProductName = product.ProductName;
            product.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;
            
        }
    }
}
