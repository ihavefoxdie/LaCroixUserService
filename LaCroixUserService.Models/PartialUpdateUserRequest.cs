using LaCroix.UserService.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LaCroix.UserService.Models
{
    public class PartialUpdateUserRequest
    {
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Name { get; set; }

        [MinLength(8)]
        public string? Password { get; set; }

        public Gender? Gender { get; set; }

        public DateTime? Birthday { get; set; }
    }
}
