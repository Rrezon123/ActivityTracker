using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ActivityTracker.Models
{
    public class ToDo
    {
        [Key]
        public int ToDoId{get;set;}
        public int UserId{get;set;}
        [Required(ErrorMessage="Must have a Title more than 4 letters")]
        [MinLength(4)]
        public string Title{get;set;}
        public string Description{get;set;}
        [Required(ErrorMessage="Give a Status")]
        public byte Status{get;set;}

        public string Importance{get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public User UserOfTask{get;set;}
        
    }
}