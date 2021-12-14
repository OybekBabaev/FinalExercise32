using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Database;
using System.Threading.Tasks;

namespace MvcStartApp.Models
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext context;

        public BlogRepository(BlogContext ctx) => context = ctx;

        public async Task AddUser(User user)
        {
            user.JoinDate = System.DateTime.Now;
            user.Id = System.Guid.NewGuid();

            var entry = context.Entry(user);
            if (entry.State == EntityState.Detached)
                await context.Users.AddAsync(user);

            await context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers() => await context.Users.ToArrayAsync();
    }
}
