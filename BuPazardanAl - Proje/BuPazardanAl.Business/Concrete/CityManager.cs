using BuPazardanAl.Business.Abstract;
using BuPazardanAl.DataAccess.Abstract;
namespace BuPazardanAl.Business.Concrete
{
    public class CityManager : ICityService
    {
        public ICityDal _cityDal { get; set; }
        public CityManager(ICityDal cityDal) => _cityDal = cityDal;
    }
}
