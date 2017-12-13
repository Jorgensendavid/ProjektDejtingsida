using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Repository;

namespace Projekt.Models 
{
    public class User :  IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
       public int Pnumber { get; set; }
        public int Age { get; set; }
        public string About { get; set; }

        public int signinID { get; set; }
        public virtual SignIn SignIn { get; set; }

    }
}