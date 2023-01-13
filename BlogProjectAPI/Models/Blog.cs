using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectAPI.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string BodyContent { get; set; }
        public DateTime postedDate { get; set; }
        public int BlogPostNumber { get; set; }
        public int UserId { get; set; }
        public IdentityUser identityUser { get; set; }
    }
}
