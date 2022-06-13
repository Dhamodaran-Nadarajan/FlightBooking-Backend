using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.DTO
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public char Gender { get; set; }

        [Range(1, 999999999)]
        public int ContactNumber { get; set; }
    }
}
