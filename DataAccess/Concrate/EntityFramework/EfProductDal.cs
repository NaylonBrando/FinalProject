using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrate.EntityFramework
{
    //EfEntityRepositoryBase'de IProductDal'ın istediği imzalar var
    //Peki hala IProductDal'a neden ihtiyac var ?
    //Business IProductDal'a bağlıdır. Ek olarak IProductDala o projeye özel operasyonlar kodlamak için.
    //o özel operasyonları EfEntityRepositoryBase'ye yazarsak diğer projelerde gereksiz yere şablon olarak kullanabilir
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId //join'deki "=" yerine equals
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnıtsInStock = p.UnitsInStock
                             };
                return result.ToList();// ToList eklememizin nedeni result'un IQuieriable olmasıdır.
            }
        }
    }
}