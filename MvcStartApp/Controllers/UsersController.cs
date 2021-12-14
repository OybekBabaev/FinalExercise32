using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models;
using MvcStartApp.Models.Database;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository blogRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IBlogRepository blogRepo, ILogger<UsersController> logger)
        {
            _logger = logger;
            blogRepository = blogRepo;
        }

        public async Task<IActionResult> Index() =>
            View((await blogRepository.GetUsers()).OrderBy(s => s.JoinDate));

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(User newbie)
        {
            await blogRepository.AddUser(newbie);
            return View(newbie);
        }
    }
}
