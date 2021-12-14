using MvcStartApp.Models.Database;
using System.Threading.Tasks;

namespace MvcStartApp.Models
{
    public interface ILogsRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
