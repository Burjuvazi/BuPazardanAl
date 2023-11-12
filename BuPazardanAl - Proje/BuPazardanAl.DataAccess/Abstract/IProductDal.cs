using BuPazardanAl.Core.DataAccess.EntityFramework;
using BuPazardanAl.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
     public List<Product> ProductWithCategory() => _set.Include(x => x.Category).ToList();
     public Product GetProductWithCategoryById(int id) => _set.Include(x => x.Category).FirstOrDefault(x=>x.Id == id);
    }
}
