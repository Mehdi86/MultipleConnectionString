using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultipleConnectionString_Test.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleConnectionString_Test.Controllers
{
    public class HomeController : GenericController
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext _appContext = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _appContext = new AppDbContext();
        }

        public IActionResult Index()
        {
            ViewBag.fullUrl = ProjectName();
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.fullUrl = ProjectName();
            return View();
        }

        /// <summary>
        /// زمانی که پروژه را پابلیش میگیریم، دیتا به دیتابیس اضاف نمیکند
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewBag.fullUrl = ProjectName();
            UserIdentity userIdentity = new UserIdentity()
            {
                Address = "Test",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                PostCode = "Test"
            };
            _appContext.fullPathUrl = ProjectName();
            _appContext.UserIdentity.Add(userIdentity);
            _appContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
