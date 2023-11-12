using BuPazardanAl.Core.Entities;

namespace BuPazardanAl.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }

        // Relational properties
        public ICollection<Product> Products { get; set; }
    }
}
