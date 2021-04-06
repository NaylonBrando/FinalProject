using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        //SOLID
        //Open Closed Principle
        private static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("-------------------------------------");

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName + " " + product.CategoryId);
            }

            Console.WriteLine("-------------------------------------");

            foreach (var product in productManager.GetByUnitPrice(20, 100))
            {
                Console.WriteLine(product.ProductName + " " + product.UnitPrice);
            }

            Console.WriteLine("-------------------------------------");

            WorkerManager workerManager = new WorkerManager(new EfWorkerDal());

            foreach (var worker in workerManager.GetAll())
            {
                Console.WriteLine(worker.Id + " " + worker.Name + " " + worker.Surname);
            }
        }
    }
}