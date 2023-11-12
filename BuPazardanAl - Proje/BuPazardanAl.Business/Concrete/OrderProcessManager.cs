using BuPazardanAl.Business.Abstract;
using BuPazardanAl.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Business.Concrete
{
    public class OrderProcessManager : IOrderProcessService
    {
        public IOrderDal _orderDal { get; set; }
        public IProductDal _productDal { get; set; }
        public IProductOrderDal _productOrderDal { get; set; }

        public OrderProcessManager(IOrderDal orderDal, IProductDal productDal, IProductOrderDal productOrderDal)
        {
            _orderDal = orderDal;
            _productDal = productDal;
            _productOrderDal = productOrderDal;
        }

    }
}
