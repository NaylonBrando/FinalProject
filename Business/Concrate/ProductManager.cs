using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
        //Bussiness sınıfı bir nevi dolaylı yoldan DataAccess siniri kullanacak, kendiside DataAccess'ten farklı olarak burada kurallar koyarak DataAccess'i kullanacak.
        private IProductDal _productDal;
        private ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Yeni, attribute ile kurulan validator. ProductValidator
        //Kullanmamizin nedeni cache, loglama vs için bir sürü kod yazmak yerine aop'nin attributesini kullaniyoruz
        //[ValidationAspect(typeof(ProductValidator))] //add metodunu productvalidator'daki kurallara göre doğrula
        //ValidationAspect çok içe içe implemente edilen classların dibinden(Attribute) attribute yeteneği almıştır
        public IResult Add(Product product) //IResult kendisini implement eden Result' döndürür
        {
            //İs kodları
            //ürün ismi aynı olan ürünü ekleme, 1 kategoriden 15 ten fazla ürün olamaz, kategori sayisi max 15

            IResult result = BusinessRules.Run(CheckIfProductOfCategoryCorrect(product.CategoryId),
                CheckIfProductOfNameExits(product.ProductName), CheckIfCategoryLimitExceded()); //yarın yeni kural geldiğinde virgülle kural ekle

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            //Eski, direkt sınıf ile kurulan validator. ProductValidator
            //validation -----> minimum kaç karakter, hangi karakterler gibi doğrulama
            //ValidationTool.Validate(new ProductValidator(), product);
        }

        public IResult Delete(Product product)
        {
            //Sonradan bu iş kuralını düzenle !
            var check = _productDal.Get(p => p.ProductName == product.ProductName); //not: tabloda aynı isimli product varsa hata verir
            if (check != null)
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
            if (check != null || check2 != null)
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

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
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

        private IResult CheckIfProductOfCategoryCorrect(int categoryId) //İş kurali PARCACİGİ oldugu için private.
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductOfNameExits(string productName)
        {
            var result = _productDal.Get(p => p.ProductName == productName); //not: tabloda aynı isimli product varsa hata verir
            if (result != null)
            {
                return new ErrorResult("Böyle bir ürün var!");
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded() //product için categoryservisi nasil yorumladigindan dolayi buraya koyduk. categorye koysak ek basina servis
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceed);
            }
            return new SuccessResult();
        }
    }
}