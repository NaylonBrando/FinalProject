using Core.Entities;

namespace Entities.Concrate
{
    public class Worker:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
