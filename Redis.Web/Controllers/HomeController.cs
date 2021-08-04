using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Redis.Helper;
using Redis.Web.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RedisService _redisService;
        public HomeController(ILogger<HomeController> logger, RedisService redisService)
        {
            _logger = logger;
            _redisService = redisService;
        }
        public string listDevelopersKey = "developers";
        public IActionResult Index()
        {
            List<DeveloperModel> developerList = _redisService.GetList<DeveloperModel>(listDevelopersKey);
            return View();
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
