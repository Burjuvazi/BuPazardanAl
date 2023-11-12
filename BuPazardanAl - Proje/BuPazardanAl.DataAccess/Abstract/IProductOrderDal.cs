using BuPazardanAl.Core.DataAccess.EntityFramework;
using BuPazardanAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.DataAccess.Abstract
{
    public interface IProductOrderDal : IRepository<ProductOrder>
    {
    }
}
