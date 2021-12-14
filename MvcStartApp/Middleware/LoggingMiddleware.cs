using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using MvcStartApp.Models.Database;
using MvcStartApp.Models;

namespace MvcStartApp.Middleware
{
    public class LoggingMiddleware
    {
        private RequestDelegate next;
        private ILogsRepository logsRepository;

        public LoggingMiddleware(RequestDelegate reqDel, ILogsRepository logRepo)
        {
            next = reqDel;
            logsRepository = logRepo;
        }

        private async Task LogRequest(HttpContext context)
        {
            string requestPath = 
                $"http://{ context.Request.Host.Value }{ context.Request.Path }";

            Request request = new()
            {
                Url = requestPath,
                Id = Guid.NewGuid(),
                Date = DateTime.Now
            };

            await logsRepository.AddRequest(request);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);

            await next(context);
        }
    }
}
