using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext") {

        }
        public DbSet<User> Users { get; set; }


    }
}