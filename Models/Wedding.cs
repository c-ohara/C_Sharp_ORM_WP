using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}
        public int UserId {get;set;}
        [Required]
        public string WedderOne {get;set;}
        [Required]
        public string WedderTwo {get;set;}
        [Required]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime WDate {get;set;}
        [Required]
        [Display(Name = "Wedding Address")]
        public string Address {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //Navigate
        public List<RSVP> Reservations {get;set;}
        public User Planner {get;set;}
        public string HappyCouple
        {
            get {
                return WedderOne + " & " + WedderTwo;
            }
        }
    }
}