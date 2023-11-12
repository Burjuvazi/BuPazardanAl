using AutoMapper;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Concrete.Dtos;

namespace BuPazardanAl.Business.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
             CreateMap<AppUser,RegisterDto>().ReverseMap();
        }
    }
}
