using BuPazardanAl.Business.Abstract;
using BuPazardanAl.DataAccess.Abstract;

namespace BuPazardanAl.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public ICategoryDal _categoryDal { get; set; }
        public CategoryManager(ICategoryDal categoryDal) => _categoryDal = categoryDal;


        
    }
}
