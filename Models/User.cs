using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "You know the drill by now.")]
        public string FirstName {get;set;}
        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "You know the drill by now.")]
        public string LastName {get;set;}
        [Required]
        [RegularExpression("^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+.[a-zA-Z]+$", ErrorMessage = "Not a valid email address")]
        public string Email {get;set;}
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        [Required]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password does not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPW {get;set;}

        //Navigate
        List<RSVP> GuestAt {get;set;}
        List<Wedding> WedPlans {get;set;}

        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }
    }

    public class Login
    {
        [Required]
        [Display(Name = "Email")]
        public string EmailAttempt {get;set;}
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PasswordAttempt {get;set;}
    }
}