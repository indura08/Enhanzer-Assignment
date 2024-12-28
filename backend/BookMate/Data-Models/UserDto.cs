using System.ComponentModel.DataAnnotations;

namespace BookMate.Data_Models
{
    public class UserDto
    {
        public string Phone {  get; set; }
        public string Role { get; set; }
        public string City { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty; 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

    }
}
