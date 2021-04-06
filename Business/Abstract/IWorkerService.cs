using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkerService
    {
        List<Worker> GetAll();

    }
}
