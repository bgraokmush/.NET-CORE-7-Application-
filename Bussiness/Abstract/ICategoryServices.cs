using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface ICategoryServices
    {
        List<Category> GetAll();
        Category GetByID(int categoryID);
        
    }
}
