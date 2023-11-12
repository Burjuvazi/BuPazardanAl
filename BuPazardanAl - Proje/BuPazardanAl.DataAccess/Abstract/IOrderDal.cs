using BuPazardanAl.Core.DataAccess.EntityFramework;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        public OrderProcessDto GetOrderProcess()
        {
            OrderProcessDto join =
                _set.Include(x => x.ProductOrders).Select(x => new OrderProcessDto()
                {
                    ProductOrders = x.ProductOrders.ToList(),
                    Orders = _set.ToList(),
                    Products = context.Set<Product>().ToList()
                }).FirstOrDefault();
            return join;
        }
    }
}
