using Aman_MVCTest_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Aman_MVCTest_.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts

        BlogDbContext db = new BlogDbContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            User user = db.Users.FirstOrDefault(x => x.UserName == model.UserName);

            if (user != null)
            {
                if (user.Password == model.Password)
                {
                    if (user.Role == "Admin")
                    {

                        Session["username"] = model.UserName;
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (user.Role == "User")
                    {
                        Session["ID"] = user.UserId;
                        Session["username"] = model.UserName;
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
                        return RedirectToAction("Index", "Blogs");
                    }

                }
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }


        }




        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Login");
        }





        // GET: Users/Create
        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                User user1 = db.Users.FirstOrDefault(emp => emp.UserName == user.UserName);

                if (user1 == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Accounts");
                }
                else
                {
                    ModelState.AddModelError("", " User Already exists");
                }
            }

            return View(user);
        }


    }
}





