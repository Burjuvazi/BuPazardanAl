using BuPazardanAl.Core.Entities;

namespace BuPazardanAl.Entities.Concrete
{
    public class SellerProduct : IEntity
    {
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }

        public Seller Seller { get; set; }
        public Product Product { get; set; }
    }
}
