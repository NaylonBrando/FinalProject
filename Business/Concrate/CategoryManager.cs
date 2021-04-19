using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

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

        public List<Category> GetAll()
        {
            //İş kodları
            return _categoryDal.GetAll();
            
        }

        public List<Category> GetById(int categoryId)
        {
            throw new NotImplementedException();
        }



        //public List<Category> GetById(int categoryId)
        //{
        //    //select * from Categories where categoryId = 3
        //    return _categoryDal.Get(c => c.CategoryId == categoryId);
        //}
    }
}
