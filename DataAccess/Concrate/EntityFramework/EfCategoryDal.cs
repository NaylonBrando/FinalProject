using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}