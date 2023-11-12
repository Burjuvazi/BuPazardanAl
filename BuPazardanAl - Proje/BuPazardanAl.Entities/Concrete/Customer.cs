using BuPazardanAl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; } = 1;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public string PhoneNumber { get; set; }
        // Relational properties
        public City City { get; set; }
        public ICollection<Order> Orders { get; set; }
        public AppUser AppUser { get; set; }
    }
}
