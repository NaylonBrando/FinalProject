using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        //IProductDal sayesinde dataaccess'teki EfProductDal ve InMemoryProductDal'a erişebiliyoruz.
        //Yani hangisini parametre olarak girersek DataAccess'teki o teknolojinin nesnesi olup, o metodları kullanabilecek.
        //Çünkü interfaceden inherit eden sınıflar(EfProductDal ve InMemoryProductDal) o interfaceye referanslarını verebilir.
        //Bussiness sınıfı bir nevi dolaylı yoldan DataAccess sınıfını kullanacak, kendiside DataAccess'ten farklı olarak burada kurallar koyarak DataAccess'i kullanacak.
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İs kodları
            //Yetkisi var mi?
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}