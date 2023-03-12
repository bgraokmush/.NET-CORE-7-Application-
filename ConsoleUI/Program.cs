using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

ProductTest();

//CategoryTest();

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    var result = productManager.GetProductDetails();

    if (result.Succes)
    {
        foreach (var product in result.Data)
        {
            Console.WriteLine(product.CategoryName + "/" + product.ProductName);
        }
    }
    Console.WriteLine(result.Message);
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (Category item in categoryManager.GetAll())
    {
        Console.WriteLine(item.CategoryName);
    }
}

