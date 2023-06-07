using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Order_Item
    {
        [Key]
        [Required]
        public int OrderItemID { get; set; }
        [Required]
        public int ItemID { get; set; }
        
        public int OrderID { get; set; }

        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        [ForeignKey("ItemID")]
        public Menu Menu { get; set; }
    }
}
