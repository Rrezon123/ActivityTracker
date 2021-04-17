using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ActivityTracker.Models
{
    public class ViewModelToDo
    {
        public List<ToDo> ListOfToDos{get;set;}
        public ToDo ToDo{get;set;}
    }
}