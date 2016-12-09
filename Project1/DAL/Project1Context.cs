using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project1.Models;
using System.Data.Entity;

namespace Project1.DAL
{
    public class Project1Context : DbContext
    {
        public Project1Context() : base("Project1Context")
        {

        }
            public DbSet<Users> User {get; set;}
            public DbSet<Degrees> Degree {get; set;}
            public DbSet<DegreeQuestions> DegreeQuestion {get; set;}
    }
}