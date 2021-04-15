using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.Models{
    public class ToDoContext :DbContext{
        public ToDoContext(DbContextOptions options):base(options){}
        public DbSet<User> Users{get;set;}
        public DbSet<Team> Teams{get;set;}
        public DbSet<ToDo> ToDos{get;set;}
    }
}