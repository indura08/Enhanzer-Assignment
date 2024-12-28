using Microsoft.AspNetCore.Identity;

namespace BookMate.Data_Models
{
    public class User : IdentityUser
    {
        //public string Username { get; set; }
        //public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Role { get; set; }


    }
}
