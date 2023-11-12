using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuPazardanAl.Business.Abstract
{
    public interface ICityService
    {
        public ICityDal _cityDal { get; set; }

        Task<City> GetCityAsync(int id) => _cityDal.GetAsync(x=>x.Id == id);

        Task<List<City>> GetCitiesAsync() => _cityDal.GetAllAsync();

        async Task<List<City>> GetOrderCitiesAsync(string orderBy)
        {
            if (orderBy != "desc")
                return (await _cityDal.GetAllAsync()).OrderBy(x => x.Name).ToList();
            return (await _cityDal.GetAllAsync()).OrderByDescending(x=>x.Name).ToList();
        }


        async Task<bool> AddCityAsync(City city)  => await _cityDal.AddAsync(city) > 0;


        async Task<bool> UpdateCityAsync(City city) => await _cityDal.UpdateAsync(city) > 0;


        async Task<bool> DeleteCityAsync(int cityId)
        {
            City city = await GetCityAsync(cityId);
            bool response =  await _cityDal.RemoveAsync(city) > 0;
            return response;
        }

    }
}
