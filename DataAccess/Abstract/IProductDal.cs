using Core.DataAccees;
using Entities.Concrate;

namespace DataAccess.Abstract
{
    //Dal:Data Access Layer.
    //Product ile ilgili operasyonlarimizin interfacesi.
    //Veri erişim işlerimizi yapacak interface
    public interface IProductDal : IEntityRepository<Product>
    {
        //IEntityRepository<Product>'in generic(<T>)i sayesinde şablon'un şablonunu kullandik.
        //Yani alltaki metodlara ihtiyac kalmadi.
        //List<Product> GetAll();
        //void Add(Product product);
        //void Delete(Product product);
        //void Update(Product product);
        //List<Product> GetAllByCategory(int categoryId);
    }
}   //Code Refactoring