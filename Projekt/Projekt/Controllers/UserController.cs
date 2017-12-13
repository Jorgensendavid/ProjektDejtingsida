using Projekt.Models;
using Projekt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class UserController : Controller
    {
        private DataContext dataContext = new DataContext();
        public ActionResult Index() {
            var allUsers = dataContext.Users.ToList();
            return View(allUsers);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid == false)
                return View();
            dataContext.Users.Add(user);
            
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}