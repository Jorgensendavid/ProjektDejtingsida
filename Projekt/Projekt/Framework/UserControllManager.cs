using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Projekt.Models;

namespace Projekt.Framework
{
    public class UserControllManager : UserManager<User>
    {
        public UserControllManager(IUserStore<User> store ) : base(store)
        {
            UserValidator = new UserValidator<User>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true

            };

            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 5,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true

            };


            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(1);
            MaxFailedAccessAttemptsBeforeLockout = 10;
        }
    }
}