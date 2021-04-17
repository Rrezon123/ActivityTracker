using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ActivityTracker.Models
{
    public class ViewModelTeam
    {
        public List<Team> ListOfTeams{get;set;}
        public Team Team{get;set;}
    }
}