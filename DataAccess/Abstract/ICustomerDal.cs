
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Concrate;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}