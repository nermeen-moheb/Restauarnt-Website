using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;

namespace Project.Models
{
    public class Customer
    {
     

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter a valid User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please enter a valid password")]
        [RegularExpression(@"^[A-Za-z0-9]+$")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare( "Password", ErrorMessage ="Doesn't match" )]
        public string? ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please enter a valid mobile number")]
       // [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$")]

        public int Mobile { get; set; }


        [Required]
        public string? address { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string? Email { get; set; }

        //[Display(Name = "ImageUser")]
        
        public string? ImageUser { get; set; }
        public ICollection <Order>? orders { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Survey>?Surveys{ get; set; }
    }
}
