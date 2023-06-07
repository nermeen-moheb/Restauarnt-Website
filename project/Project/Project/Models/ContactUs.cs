using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{



    public enum Problem
    {
        Personal_problem,General_problem

    }
    public class ContactUs
    {
        [Key]

        public int ContactId { get; set; }
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Message { get; set; }

        public Problem? Problem { get; set; }

        public int? CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? customer { get; set; }
    }
}
