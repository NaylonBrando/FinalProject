using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("-------------------------------------");

            ProductManager productManager2 = new ProductManager(new EfProductDal());

            foreach (var product in productManager2.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
