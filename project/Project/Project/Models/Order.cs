using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
     
        public decimal Total_price { get; set; }

        public Customer Customer { get; set; }
        public List<Order_Item> Order_Items { get; set; }
    }
}
