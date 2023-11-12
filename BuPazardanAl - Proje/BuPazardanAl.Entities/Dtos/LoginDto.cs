using BuPazardanAl.Core.Entities;

namespace BuPazardanAl.Entities.Concrete.Dtos
{
    public class LoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;
    }
}
