using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class Reservation
    {
        [Key]

        public int? ReservationID { get; set; }

        [Required(ErrorMessage = "This table is reserved")]
        public int? TableID { get; set; }


       
        public int CustomerID { get; set; }


    
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        


        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("TableID")]
        public virtual Table? Table { get; set; } 
    }
}
