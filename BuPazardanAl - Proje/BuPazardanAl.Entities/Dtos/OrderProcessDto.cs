using BuPazardanAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Entities.Dtos
{
    public class OrderProcessDto
    {
        public List<Order> Orders { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public List<Product> Products { get; set; }
    }
}
