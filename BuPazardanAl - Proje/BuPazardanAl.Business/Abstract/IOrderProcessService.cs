using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Business.Abstract
{
    public interface IOrderProcessService
    {
         public IOrderDal _orderDal { get; set; }
         public IProductDal _productDal { get; set; }
        public IProductOrderDal _productOrderDal { get; set; }

        public OrderProcessDto GetOrderDetails()
        {
            return _orderDal.GetOrderProcess();
        }
         
        public async Task<bool> OrderAdd(OrderProductDto orderProductDto)
        {
            try
            {
                int response = _orderDal.AddAsync(new Order() { CustomerId = orderProductDto.CustomerId }).Result;
                int orderId = _orderDal.GetAllAsync().Result.Max(x => x.Id);
                response = _productOrderDal.AddAsync(new ProductOrder() { Price = orderProductDto.Price, Quantity = orderProductDto.Quantity, ProductId = orderProductDto.ProductId, OrderId = orderId, TotalPrice = orderProductDto.Quantity * orderProductDto.Price }).Result;

                Product product = _productDal.GetAsync(x => x.Id == orderProductDto.ProductId).Result;
                product.StockAmount -= orderProductDto.Quantity;
                await _productDal.UpdateAsync(product);
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        
        }
    }
}
