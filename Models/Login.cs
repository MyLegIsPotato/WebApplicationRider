﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationRider.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}