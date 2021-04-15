using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ActivityTracker.Models{
    public class Team{
        [Key]
        public int TeamId { get;set;}
        public int UserId { get;set;}

        public string TeamName{get;set;}
        public List<User> AllUsers { get;set;}
    }
}