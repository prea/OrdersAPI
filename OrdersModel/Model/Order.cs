using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersModel.Model
{
    public class Order 
    {   
        [Key]
        public int Id { get; set; }
        public List<OrderItems> OrderItems { get; set; }

        public decimal Total { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "The Delivery Address must be less then 200 characters")]
        public string DeliveryAddress { get; set; }

    }
}
