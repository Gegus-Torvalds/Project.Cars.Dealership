using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cars.Dealership.Core.DTO.Auth
{
    public class RegisterDto
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
            ErrorMessage = "Password must be at least 8 chars, include an uppercase letter," +
            "a digit, and a special character.")]
        public required string Password { get; set; }


        [Required]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public required string ConfirmPassword { get; set; }
        [Required]
        public required string? FirstName { get; set; }
        [Required]
        public required string? LastName { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
