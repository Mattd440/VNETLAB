
/*
 * The Class Just Controls the "/" or "" route and only displays the HOme Page
 * 
 * 
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkConfigurator.Model;
using NetworkConfigurator.DataManager;

namespace NetworkConfigurator.Controllers
{
    public class HomeController : Controller
    {



        // / or /index
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}