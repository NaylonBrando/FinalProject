using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class WorkerManager : IWorkerService
    {
        private IWorkerDal _workerDal;

        public WorkerManager(IWorkerDal workerDal)
        {
            _workerDal = workerDal;
        }

        public List<Worker> GetAll()
        {
            return _workerDal.GetAll();
        }
    }
}