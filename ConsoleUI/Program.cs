using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        //SOLID
        //Open Closed Principle
        static void Main(string[] args)
        {
            //ProductTest1();
            Console.WriteLine("-------------------------------------");
            //ProductTest2();
            Console.WriteLine("-------------------------------------");
            ProductTest3();
            Console.WriteLine("-------------------------------------");
            //WorkerTest1();
            Console.WriteLine("-------------------------------------");
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //foreach (var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryId + " " + category.CategoryName);
            //}


        }

        private static void WorkerTest1()
        {
            WorkerManager workerManager = new WorkerManager(new EfWorkerDal());
            foreach (var worker in workerManager.GetAll())
            {
                Console.WriteLine(worker.Id + " " + worker.Name + " " + worker.Surname);
            }
        }

        private static void ProductTest3()
        {
            ProductManager productManager3 = new ProductManager(new EfProductDal());
            foreach (var product in productManager3.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + " " + product.CategoryName);
            }
        }

        private static void ProductTest2()
        {
            ProductManager productManager2 = new ProductManager(new EfProductDal());
            foreach (var product in productManager2.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName + " " + product.CategoryId);
            }
        }

        private static void ProductTest1()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}