using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersModel.Model
{
    public class OrderItems 
    {   
        [Key]
        public int Id { get; set; }
        [Required]       
        [Range(1,int.MaxValue)]
        public int ProductID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]        
        public int Qty { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
       
    }
}
