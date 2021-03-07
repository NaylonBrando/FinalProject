using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

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
    }
}
