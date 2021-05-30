using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWorkerService
    {
        List<Worker> GetAll();
    }
}