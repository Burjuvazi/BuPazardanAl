using AutoMapper;
using BuPazardanAl.Business.ValidationRules.FluentValidation;
using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.DataAccess.Concrete.EntityFrameworkCore;
using BuPazardanAl.Entities.Concrete;
using BuPazardanAl.Entities.Dtos;
using FluentValidation.Results;

namespace BuPazardanAl.Business.Abstract
{
    public interface ICustomerService
    {
        ICustomerDal _customerDal { get; set; }
        IMapper _mapper { get; set; }
        CustomerValidator rules { get; set; }
        public ValidationResult Validator(Customer customer)
        {
            return rules.Validate(customer);
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerDal.GetAsync(x => x.Id == id);
        }

        public async Task<IList<Customer>> CustomerListByName(string customerName)
        {
            return await _customerDal.GetAllAsync(x => x.FirstName == customerName);
        }

        public async Task<IList<Customer>> CustomerList()
        {
            return await _customerDal.GetAllAsync();
        }

        public async Task<IList<Customer>> CustomerListByState(bool customerState)
        {
            return await _customerDal.GetAllAsync(x => x.Status == customerState);
        }

        public async Task CustomerAdd(CustomerDto customerDto)
        {

            Customer customer = _mapper.Map<Customer>(customerDto);
            var result = Validator(customer);
            if (result.IsValid)
            {
                await _customerDal.AddAsync(customer);
            }

        }

        public async Task CustomerUpdate(Customer customer)
        {
            var result = Validator(customer);
            if (result.IsValid)
            {
                await _customerDal.AddAsync(customer);
            }
        }

        public async Task CustomerDelete(int customerId)
        {
            var customer = await GetCustomerById(customerId);
            await _customerDal.RemoveAsync(customer);
        }

    }
}
