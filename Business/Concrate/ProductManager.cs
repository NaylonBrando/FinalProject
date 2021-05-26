using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using FluentValidation;
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

        //Yeni, attribute ile kurulan validator
        [ValidationAspect(typeof(ProductValidator))] //add metodunu productvalidator'daki kurallara göre doğrula
        public IResult Add(Product product) //IResult kendisini implement eden Result' döndürür
        {
            //İs kodları
            //Yetkisi var mi?
            //İşlem gerçekleşti veya gerçekleşmedi ise ben ona göre ekledim veya eklemedim diyeyim.
            //Result metodlari ile crud operasyonlarının tek şey döndürmesinden bağımsız birden fazla değerler
            //döndürürür resutlar sayesinde.

            //Eski, direkt sınıf ile kurulan validator
            //validation -----> minimum kaç karakter, hangi karakterler gibi doğrulama 
            //ValidationTool.Validate(new ProductValidator(), product);
            
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //Interface'nin kendisini implemente eden sınıfların referansını tutması.
        }
        public IResult Delete(Product product)
        {
            var check = _productDal.Get(p => p.ProductName == product.ProductName); //not: tabloda aynı isimli product varsa hata verir
            if (check!=null)
            {
                _productDal.Delete(product);
                return new SuccessResult("Ürün Silindi");
            }
            return new SuccessResult("Böyle isimde ürün yok! ");


        }
        public IResult Update(Product product)
        {
            var check = _productDal.Get(p => p.ProductName == product.ProductName);
            var check2 = _productDal.Get(p => p.ProductId == product.ProductId);
            if (check != null || check2 !=null)
            {
                _productDal.Update(product);
                return new SuccessResult("Ürün Güncellendi!");
            }
            return new SuccessResult("Böyle isimde ürün yok! ");


        }


        public IDataResult<List<Product>> GetAll() //Hem product list hem bool hem de mesaj döndürüyor
        {                                          //İç içe list yapısı varmış
            //İs kodları
            //Yetkisi var mi?
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
                //Peki data null oldugu halde niye ürün listesini döndürdüm.
                //Çünkü front endçi bunu ona göre karşılıyacak, kodlarını ona göre yazacak.
            }
        

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);


        }
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id)); //filtreleme businesste yapılır. Çay Erdal bakkalda içilir
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