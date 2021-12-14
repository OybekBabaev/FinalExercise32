using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Database;
using System.Threading.Tasks;

namespace MvcStartApp.Models
{
    public class LogsRepository : ILogsRepository
    {
        private readonly BlogContext context;

        public LogsRepository(BlogContext ctx) => context = ctx;

        public async Task AddRequest(Request newReq)
        {
            if (context.Entry(newReq).State == EntityState.Detached)
                await context.Requests.AddAsync(newReq);

            await context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests() => await context.Requests.ToArrayAsync();
    }
}
