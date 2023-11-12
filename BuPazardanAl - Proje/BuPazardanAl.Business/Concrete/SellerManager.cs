using AutoMapper;
using BuPazardanAl.Business.Abstract;
using BuPazardanAl.Business.ValidationRules.FluentValidation;
using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Dtos;
using FluentValidation.Results;

namespace BuPazardanAl.Business.Concrete
{
    public class SellerManager : ISellerService
    {
        public SellerManager(ISellerDal sellerDal, IMapper mapper)
        {
            _sellerDal = sellerDal;
            _mapper = mapper;
        }

        public ISellerDal _sellerDal { get; set; }
        public IMapper _mapper { get; set; }
        public SellerValidator rules { get; set; } = new SellerValidator();
    }
}
