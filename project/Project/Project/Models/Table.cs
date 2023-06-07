using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Table
    {
        [Key]
       
        public int? TableID  { get; set; }
  
        public int? NumOfChairs { get; set; }
 
        public bool? IsAvailable { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }

       
    }
}
