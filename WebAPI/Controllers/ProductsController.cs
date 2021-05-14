using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Bu istegi yaparken bu insanlar bize nasıl ulassın. Tarayıcıda api/products
    [ApiController] //----> Attribute. Class ile ilgili bilgi verme, imzalama.
    //Bu class bir controllerdir, kendini ona göre yapılandır.
    public class ProductsController : ControllerBase
    {
       
        IProductService _productService;
        //Loosely Coupled //Gevsek bağlılıktır depency injection
        //Bir katman diğer katmanın somutu dışında bağlantı kuramaz
        //IoC Container: Inversion of Control
        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }
        [HttpGet]
        public List<Product> Get()
        {
            //Depency chain
            
            var result = _productService.GetAll(); //Get IDataResult döndürür
            return result.Data; //Gelistirme ekibine bu datayı veriyoruz o da mobil geliştirmeye itereit ediyor.
        }
    }
        //return new List<Product>
        //{
        //    new Product{ProductId=1, ProductName="Elma"},
        //    new Product{ProductId=2, ProductName="Armut"},
        //};     
    
}
