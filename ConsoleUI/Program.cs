using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        //SOLID
        //Open Closed Principle
        private static void Main(string[] args)
        {
            //ProductTest1();
            Console.WriteLine("-------------------------------------");
            CRUDOperationsTest();
            Console.WriteLine("-------------------------------------");
        }

        private static void ProductTest1()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var data = productManager.GetAll();
            foreach (var item in data.Data)
            {
                Console.WriteLine(item.ProductId + " " + item.ProductName);
            }
        }

        private static void CRUDOperationsTest()
        {
            //Notlar:
            //1: Veritabanı ıd numaralarını kendisi atıyor, biz elle vermeye kalkısırsak hata verir.
            //2: Delete ve Update operasyonunda işlem yapılack kaydın bütün parametreleri doğru girilmelidir. Updatede degisecek kısımları farklı girip, diğer kısımları da eskisi gibi girmek
            //gerekiyor

            ProductManager productManager1 = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            //var message = productManager1.Add(new Product { CategoryId = 3, ProductName = "Mehtap", UnitPrice = 999, UnitsInStock = 1 });
            //Console.WriteLine(message.Message);
            ///var message2 = productManager1.Delete(new Product { ProductId=84 ,CategoryId = 3, ProductName = "Mehtap", UnitPrice = 999, UnitsInStock = 1 });
            //Console.WriteLine(message2.Message);
            var message3 = productManager1.Update(new Product { ProductId = 86, CategoryId = 3, ProductName = "Kaplan", UnitPrice = 999, UnitsInStock = 1 });
            Console.WriteLine(message3.Message);
        }
    }
}