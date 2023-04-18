using Aman_MVCTest_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Security.Cryptography;

namespace Aman_MVCTest_.Controllers
{
   
    public class AdminController : Controller
    {
        public BlogDbContext db = new BlogDbContext();

  

        public ActionResult Index()
        {


           

            return View(db.Blogs.ToList());

        }

   
        public ActionResult Details(int? id)
        {
            Blog blog = db.Blogs.Find(id);
            return View(blog);
        }

     
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
      
        public ActionResult Create([Bind(Include = "Id,Image,Heading,Description,Author,Store")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

     
        public ActionResult Edit(int? id)
        {
           
            Blog blog = db.Blogs.Find(id);
           
            return View(blog);
        }

        [HttpPost]
        
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {

                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

      
        public ActionResult Delete(int? id)
        {
          
           
            var tempvar=db.Blogs.Find(id);

            tempvar.Disabled = "True";
            db.SaveChanges();

            ViewBag.messasge = "User Disabled SuccessFully";

            return RedirectToAction("Index");
        }

        
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

   
    }
}