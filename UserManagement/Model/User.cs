using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public char Gender { get; set; }

        public int ContactNumber { get; set; }
    }
}
