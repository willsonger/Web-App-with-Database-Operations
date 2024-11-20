using System.ComponentModel.DataAnnotations;

namespace FancySignup.Models
{
    public class UserLoginModel
    {
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!; // Acts as the primary key.

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
