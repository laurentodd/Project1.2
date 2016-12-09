using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{   [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage="Please enter an email")]
        public string Email { get; set; }

    [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

    [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }
    }
}