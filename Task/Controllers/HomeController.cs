using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task.Entities;
using Task.Models;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly TaskDbContext _Context;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, TaskDbContext context)
        {
            _logger = logger;
            this.mapper = mapper;
            _Context = context;
        }

        public IActionResult Index()
        {
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

        public IActionResult SignUp()
        {
            UserModel model = new UserModel() { };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            var result = mapper.Map<User>(model);
            
            _Context.Add(result);
            await _Context.SaveChangesAsync();
            return View();
        }
        public IActionResult Login()
        {
            UserModel model = new UserModel() { };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            var result = mapper.Map<User>(model);
            
            //_Context.Add(result);
            //await _Context.SaveChangesAsync();
            var User=  _Context.User.Where(x=>x.Email==model.Email && x.password==model.password).FirstOrDefault();
            var result2 = mapper.Map<UserModel>(User);
            if (User != null)
                return RedirectToAction("AllMessages", "User", new { Email = model.Email});
            else
                return View("Login");
        }
    }
}
