using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
    }
}