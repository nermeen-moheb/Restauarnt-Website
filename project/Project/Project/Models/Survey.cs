using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models



{
    public enum evaluation
    {
        excellent, good, average, poor, verypoor

    }
    public class Survey
    {
        [Key]

        public int SurveyId { get; set; }
        [Required]
        public evaluate FoodQuality { get; set; }
        [Required]
        public evaluate OverallService { get; set; }

        [Required]
        public evaluate Cleanliness { get; set; }

        [Required]
        public evaluate OrderAccuracy { get; set; }


        [Required]
        public evaluate SpeedofService { get; set; }

        [Required]
        public evaluate Value { get; set; }

        [Required]
        public evaluate OverallExperience { get; set; }

        [Required]
       

        public string? additionalcomments { get; set; }


        [Required]
        public string? Email { get; set; }



        public int? CustomerID { get; set; }

        [Required]
        public DateTime Date { get; set; }


        [ForeignKey("CustomerID")]
        public Customer? customer { get; set; }
    }
}

