using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfWorkerDal : IWorkerDal
    {
        public void Add(Worker entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Worker entity)
        {
            throw new NotImplementedException();
        }

        public Worker Get(Expression<Func<Worker, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Worker>().SingleOrDefault(filter);//Dbsetlerinden producte bağlan
            }
        }

        public List<Worker> GetAll(Expression<Func<Worker, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Worker>().ToList() : context.Set<Worker>().Where(filter).ToList();
            }
        }

        public void Update(Worker entity)
        {
            throw new NotImplementedException();
        }
    }
}
