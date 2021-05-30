using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Bu istegi yaparken bu insanlar bize nasıl ulassın. Tarayıcıda api/products
    [ApiController] //----> Attribute. Class ile ilgili bilgi verme, imzalama.
    //Bu class bir controllerdir, kendini ona göre yapılandır.
    public class ProductsController : ControllerBase //Controllere isim verirken hangi nesne olduguna dikkat ederek s takisi + controller diye yaratin sinifinizi
    {
        private IProductService _productService;

        //Loosely Coupled //Gevsek bağlılıktır depency injection
        //Bir katman diğer katmanın somutu dışında bağlantı kuramaz
        //IoC Container: Inversion of Control
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] //getall alliance verdik. sql gibi isim ekleme
        public IActionResult Get()
        {
            //Depency chain
            var result = _productService.GetAll(); //Get IDataResult döndürür
            if (result.Success == true)
            {
                return Ok(result); //ok--> http statu kodu 200 //Gelistirme ekibine bu datayı veriyoruz o da mobil geliştirmeye itereit ediyor.
            }
            return BadRequest(result); //http statü bad request 400
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product); //Veriyi postmandan alıyoruz. postman/post
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

    //return new List<Product>
    //{
    //    new Product{ProductId=1, ProductName="Elma"},
    //    new Product{ProductId=2, ProductName="Armut"},
    //};
}