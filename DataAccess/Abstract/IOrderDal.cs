﻿using Core.DataAccess;
using Entities.Concrate;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}