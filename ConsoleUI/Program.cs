using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using System;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        //SOLID
        //Open Closed Principle
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("-------------------------------------");

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName + " "+ product.CategoryId);
            }

            Console.WriteLine("-------------------------------------");

            foreach (var product in productManager.GetByUnitPrice(20,100))
            {
                Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            }

            
        }
    }
}
