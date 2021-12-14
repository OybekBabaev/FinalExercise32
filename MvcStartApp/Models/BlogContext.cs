using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Database;

namespace MvcStartApp.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> Posts { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
