using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aman_MVCTest_.Models
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext() : base("name=MyConnectionString")
        {

        }
        //Adding Domain Classes as DbSet
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}