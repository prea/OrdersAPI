using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersModel.Model
{   
    public class User 
    {
      
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Username must be less then 50 characters")]
        public string Username { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Password  must be less then 50 characters")]
        public string Password { get; set; }
    }
}
