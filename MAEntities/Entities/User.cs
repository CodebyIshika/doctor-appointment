using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAEntities.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [StringLength(20)]
        public string ContactNumber { get; set; }

        public string Role { get; set; }
    }
}
