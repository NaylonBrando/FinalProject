using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class CategoryManager : ICategoryService
    {
        //Bagımlılığı minimize etmek için depency injection ---> constructor injection

        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IDataResult<List<Category>> GetAll()
        {
            //İş kodları
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
        //select * from Categories where categoryId = 3
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        private IResult CheckIfCategoryLimitExceded() //İş kurali PARCACİGİ oldugu için private.
        {
            var result = _categoryDal.GetAll().Count;
            if (result >= 15)
            {
                return new ErrorResult("Maximum kategori liniti asildi!");
            }
            return new SuccessResult();
        }

    }
}