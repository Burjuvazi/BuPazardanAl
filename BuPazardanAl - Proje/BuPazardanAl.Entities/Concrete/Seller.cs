using BuPazardanAl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Entities.Concrete
{
    public class Seller : IEntity
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }

        public ICollection<SellerProduct> SellerProducts { get; set; }
        public AppUser AppUser { get; set; }

    }
}
