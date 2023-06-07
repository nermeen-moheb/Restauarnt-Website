using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models

{
    public class Cart
    {
        [Key]
        public int cartID { get; set; }

        public int CustomerID { get; set; }

        public int ItemId { get; set; }

        public int quantity { get; set; }

        [ForeignKey("ItemId")]
        public Menu Item { get; set; }
    }
   
}
