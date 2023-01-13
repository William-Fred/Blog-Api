using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BlogProjectAPI.Models
{
    public class BlogContext : IdentityUserContext<IdentityUser>
    {
        public BlogContext(DbContextOptions<BlogContext> options)
           : base(options)
        {

        }
       public DbSet<Blog> Blogs { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
