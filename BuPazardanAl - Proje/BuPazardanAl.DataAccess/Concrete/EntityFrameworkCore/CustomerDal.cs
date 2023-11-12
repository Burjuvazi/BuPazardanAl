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
    public class CustomerDal : RepositoryBase<Customer>,ICustomerDal
    {
        public CustomerDal(BuPazardanAlContext context):base(context)
        {
            
        }
    }
}
