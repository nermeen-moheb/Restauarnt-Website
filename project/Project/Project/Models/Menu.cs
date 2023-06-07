using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Menu
    {
        [Key]
        
        public int? ItemID { get; set; } 
        public string? ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string? ItemDescription { get; set; }
        public string?ImagePath { get; set; }
        public string? Category { get; set; }
        public List<Order_Item> ?Order_Items { get; set; }
    }
}
