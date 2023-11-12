

using BuPazardanAl.Core.Entities;

namespace BuPazardanAl.Entities.Concrete.Dtos
{
    public class RegisterDto : IDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
