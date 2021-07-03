using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //IDataResult, hem işlem sonucu hem de productun listini döndüreceği için iç içe halde

        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int id); //Product Listi döndürmez. Product, bool ve mesajdan oluşan bir liste döndürür.

        IResult Add(Product product);//Void için IResult

        IResult Update(Product product);

        IResult Delete(Product product);
        IResult AddTransactionalTest(Product product);
    }
}