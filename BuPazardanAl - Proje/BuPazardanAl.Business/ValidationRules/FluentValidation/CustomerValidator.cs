using BuPazardanAl.Entities.Concrete;
using FluentValidation;


namespace BuPazardanAl.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        { 
        }
    }
}
