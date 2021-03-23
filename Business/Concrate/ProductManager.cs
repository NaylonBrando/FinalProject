using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal) //IProductDal sayesinde dataaccess'teki EfProductDal ve InMemoryProduct dal a erişebiliyoruz.
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
    }
}