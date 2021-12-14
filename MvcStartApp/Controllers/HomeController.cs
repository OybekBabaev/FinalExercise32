using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models;
using MvcStartApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository blogRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IBlogRepository blogRepo, ILogger<HomeController> logger)
        {
            _logger = logger;
            blogRepository = blogRepo;
        }

        public async Task<IActionResult> Index() => View();
    }
}
