using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ActivityTracker.Models{
    public class User{
        [Key]
        public int UserId { get; set; }
        public int TeamId{get;set;}

        [Display(Name="First Name")]
        [Required(ErrorMessage = "It needs to have a First Name")]
        [MinLength(2, ErrorMessage = "At least two characters")]
        public string FirstName { get; set; }

        [Display(Name= "Last Name")]
        [Required(ErrorMessage = "It needs to have a Last Name")]
        [MinLength(2, ErrorMessage = "At least two characters")]
        public string LastName { get; set; }

        [Display(Name="Email")]
        [EmailAddress(ErrorMessage = "Not an Email")]
        public string Email { get; set; }

        [Display(Name="Password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "At least 8 characters")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$",ErrorMessage="Password must contain atleast 1 number, 1 letter, and 1 special character.")]
        public string Password{ get; set; }



        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "At least 8 characters")]
        [NotMapped]
        public string ConfirmPassword{ get; set; }

        public string ImgUrl{get;set;}

        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<ToDo> AllTasks{get;set;}
        public Team CurrentTeam{get;set;}
    }
    public class LoginUser
    {
        [EmailAddress]
        [Required]
        [Display(Name="Email")]
        public string EmailLogin{get;set;}
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string PasswordLogin {get;set;}
    }
}