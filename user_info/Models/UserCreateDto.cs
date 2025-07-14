using Microsoft.AspNetCore.Http;

namespace user_info.Models
{
    public class UserCreateDto
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile CVFile { get; set; }
    }
}
