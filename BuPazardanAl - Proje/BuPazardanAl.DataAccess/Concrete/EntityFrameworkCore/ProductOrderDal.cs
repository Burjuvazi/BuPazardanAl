using BuPazardanAl.Core.DataAccess.EntityFramework;
using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore.Context;
using BuPazardanAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore
{
    public class ProductOrderDal : RepositoryBase<ProductOrder>,IProductOrderDal
    {
        public ProductOrderDal(BuPazardanAlContext context):base(context)
        {
                
        }
    }
}
