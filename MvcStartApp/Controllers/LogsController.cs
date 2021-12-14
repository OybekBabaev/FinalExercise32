using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogsRepository logsRepository;

        public LogsController(ILogsRepository logRepo) => logsRepository = logRepo;

        public async Task<IActionResult> Index() => 
            View(await logsRepository.GetRequests());
    }
}