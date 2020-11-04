using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your surname")] // атрибут валідації
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your phonenumber")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Enter your email")]
        public string Email { get; set; } 
    }
}
