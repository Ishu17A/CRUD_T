using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aman_MVCTest_.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }


        public string Image { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        public string Author { get; set; }
        public Guid Store { get; set; }

        public string Disabled { get; set; } = "False";

    }
}