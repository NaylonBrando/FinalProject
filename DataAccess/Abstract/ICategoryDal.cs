using Core.DataAccess;
using Entities.Concrate;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}