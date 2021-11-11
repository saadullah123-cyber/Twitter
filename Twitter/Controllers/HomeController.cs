using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var post =await context.post.OrderByDescending(x=>x.ID).ToListAsync();
            return View(post);
        }
        [HttpPost]
        public async Task<JsonResult> Save(string message)
        {
            try
            {
                post post = new post();
                post.Message = message;
               
                context.post.Add(post);
                await context.SaveChangesAsync();
                return Json("OK");
            }
            catch (Exception ex)
            {
                return Json("Error");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
