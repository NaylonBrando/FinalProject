using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Bu list, bellekte sanki veri varmis da onu simule edecegiz diye kodlanmistir.
        private List<Product> _products; //Global degisken(olusturuldugu classa göre). Bu siniftaki bütün metodlar bu degiskene erisebilir.

        //Global degiskenlerin isimleri "_" ile baslar.

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName ="Kristal Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName ="Cam Bardak", UnitPrice=15, UnitsInStock=20},
                new Product{ProductId=3,CategoryId=1,ProductName ="Çelik Bardak", UnitPrice=15, UnitsInStock=25},
                new Product{ProductId=4,CategoryId=1,ProductName ="Bor Bardak", UnitPrice=15, UnitsInStock=30},
                new Product{ProductId=5,CategoryId=1,ProductName ="Plütonyum Bardak", UnitPrice=15, UnitsInStock=36}
                //Her product'un referans adresi farklidir.
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Peki ürünleri silmek için bizim neye ihtiyacimiz var ? Ürünler her newlendiğinde
            //referans idsi farklı olacagindan, bizim ürünleri id'sine göre silmemiz gerekir.
            //Bunun icinde listeyi tek tek dolasmamiz lazim.
            Product productToDelete = null; //silinecek productun referansını tutan class.
            //1. Yöntem
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            //2. Yöntem
            //LINQ - Language İntegrated Language. Link ile liste bazlı yapıları sql ile filtreleyebiliriz.
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //singleordefault tek bir eleman bulmaya yarar. producsu tek tek dolasır.
            //p=> Lambda nedir. Parametrenin icindeki p, foreach döngüsündeki item ile degisken tutmanin mantiginda.
            //p nin dolastigi elemanlarin id'lerinden biri product parametresinin id'sine eşit ise ;
            // productToDelete'e eslesilen p elemanının referans adresini ver.

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

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //where koşulu, içindeki şarta uyan bütün elemanları yeni bir liste haline getirip döndürür.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}