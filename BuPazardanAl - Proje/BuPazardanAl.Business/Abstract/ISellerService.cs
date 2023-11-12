using AutoMapper;
using BuPazardanAl.Business.ValidationRules.FluentValidation;
using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Business.Abstract
{
    public interface ISellerService
    {
        ISellerDal _sellerDal { get; set; }
        IMapper _mapper { get; set; }
        SellerValidator rules { get; set; }
        public ValidationResult Validator(Seller seller)
        {
            return rules.Validate(seller);
        }

        public async Task<Seller> GetSellerById(int sellerId)
        {
            return await _sellerDal.GetAsync(x => x.Id == sellerId);
        }

        public async Task SellerAdd(SellerDto sellerDto)
        {
            Seller seller = _mapper.Map<Seller>(sellerDto);
            var result = Validator(seller);
            if (result.IsValid)
            {
                await _sellerDal.AddAsync(seller);
            }

        }
        public async Task SellerDeleteById(int sellerId)
        {
            Seller seller = await GetSellerById(sellerId);
            await _sellerDal.RemoveAsync(seller);
        }

        public async Task<IList<Seller>> SellerList()
        {
            return await _sellerDal.GetAllAsync();
        }

        public async Task<IList<Seller>> SellerListByName(string sellerName)
        {
            return await _sellerDal.GetAllAsync(x => x.StoreName == sellerName);
        }

        public async Task SellerUpdate(Seller seller)
        {
            var result = Validator(seller);
            if (result.IsValid)
            {
                await _sellerDal.UpdateAsync(seller);
            }
        }
    }
}
