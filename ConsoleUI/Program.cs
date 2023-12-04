using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CategoryTest();
            ProductTest();


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

          var Result = categoryManager.GetAll();
            if (Result.Success == true) 
            {
                foreach (var category in Result.Data)
                {
                    Console.WriteLine(category.CategoryName);
                }
            }

        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();
            if (result.Success==true) 
            {
                foreach (var product in result.Data)
                {

                    Console.WriteLine(product.ProductName + "/" + product.CategoryName + "/" + product.UnitsInStock);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}