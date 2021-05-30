using Core.Utilities.Results;
using Entities.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();

        IDataResult<Category> GetById(int categoryId);
    }
}