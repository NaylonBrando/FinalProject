using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
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

        public IResult Add(Product product) //IResult kendisini implement eden Result' döndürür
        {
            //İs kodları
            //Yetkisi var mi?
            //İşlem gerçekleşti veya gerçekleşmedi ise ben ona göre ekledim veya eklemedim diyeyim.
            //Result metodlari ile crud operasyonlarının tek şey döndürmesinden bağımsız birden fazla değerler
            //döndürürür resutlar sayesinde.
            if (product.ProductName.Length < 2)
            {
                //Magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //Interface'nin kendisini implemente eden sınıfların referansını tutması.
        }

        public IDataResult<List<Product>> GetAll() //Hem product list hem bool hem de mesaj döndürüyor
        {                                          //İç içe list yapısı varmış
            //İs kodları
            //Yetkisi var mi?
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
                //Peki data null oldugu halde niye ürün listesini döndürdüm.
                //Çünkü front endçi bunu ona göre karşılıyacak, kodlarını ona göre yazacak.
            }
        

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);


        }
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}