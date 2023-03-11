using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class CategoryManager : ICategoryServices
    {
        ICategoryDal _categorDal;

        public CategoryManager(ICategoryDal categorDal)
        {
            _categorDal = categorDal;
        }

        public List<Category> GetAll()
        {
            return _categorDal.GetAll();
        }

        public Category GetByID(int categoryID)
        {
            return _categorDal.Get(c => c.CategoryId == categoryID);
        }
    }
}
