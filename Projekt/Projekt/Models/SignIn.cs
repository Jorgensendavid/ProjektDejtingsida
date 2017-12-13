using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class SignIn
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; }

        public virtual ICollection<User> user { get; set; }
    }
}