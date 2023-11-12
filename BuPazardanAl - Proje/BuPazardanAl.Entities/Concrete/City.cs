using BuPazardanAl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        // Relational properties
        public ICollection<Customer> Customers { get; set; }    
    }
}
