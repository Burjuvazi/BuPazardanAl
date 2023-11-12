using BuPazardanAl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public bool Status { get;set; }
    
        public Category Category { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public ICollection<SellerProduct> SellerProducts { get; set; }
    }
}
