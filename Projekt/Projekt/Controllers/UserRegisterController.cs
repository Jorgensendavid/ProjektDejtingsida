using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Projekt.Framework;
using Projekt.Models;

namespace Projekt.Controllers
{    [AllowAnonymous]
    public class UserRegisterController : Controller
    {

        private readonly FrameworkSignInManager frameworkSignInManager;
        private readonly UserControllManager userControllManager;
        private readonly IAuthenticationManager authenticationManager;

        public UserRegisterController(FrameworkSignInManager frameworkSignInManager, UserControllManager userControllManager,
            IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
            this.frameworkSignInManager = frameworkSignInManager;
            this.userControllManager = userControllManager;

        }

        public ActionResult SignIn(string ReturnUrl = "/")
        {

            return View(new SignIn { returnUrl = ReturnUrl});
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignIn model, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await frameworkSignInManager.PasswordSignInAsync(model.Email, model.Password, model.rememberMe,shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("LockOut");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid sign in  attempt. ");
                    return View(model);


            }
                

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);

            }
            return RedirectToAction("HomePage", "HomeController");
        }

    }


}