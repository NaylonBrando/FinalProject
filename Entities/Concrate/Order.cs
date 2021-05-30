using Core.Entities;
using System;

namespace Entities.Concrate
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderTime { get; set; }
        public string ShipCity { get; set; }
    }
}