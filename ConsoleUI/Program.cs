using Bussiness.Concrete;
using DataAccess.Concrete.InMemory;


ProductManager productManager = new ProductManager( new InMemoryProductDal());


foreach (var item in productManager.GetAll())
{
    Console.WriteLine(item.ProductName);
}