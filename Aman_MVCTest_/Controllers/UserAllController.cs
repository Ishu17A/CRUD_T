using Aman_MVCTest_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Aman_MVCTest_.Controllers
{
    public class UserAllController : Controller
    {
        // GET: UserAll
        public ActionResult Index()
        {
            BlogDbContext db = new BlogDbContext();

         

            var userData = (from emp in db.Blogs where emp.Disabled == "False" select emp).ToList();
            return View(userData);
        }
    }
}