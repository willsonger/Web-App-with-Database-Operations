using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FancySignup.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(
            @"^[A-Za-z](?=.*[a-z])(?=.*[A-Z])(?=.*\d).{7,}$",
            ErrorMessage = "Passwords must begin with a letter, include an uppercase letter, a lowercase letter, a digit, and be at least 8 characters long.")]
        public string Password { get; set; } = null!;

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
