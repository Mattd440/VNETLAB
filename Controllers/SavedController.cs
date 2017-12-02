/*
 * The Class Handles the Saved Page that Displays All the Saved Networks
 * The Detail Method Handles the /Saved/Detail Page that shows Network Details
 * The GetNetwork File Method returns JSON data of the specified network
 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkConfigurator.DataManager;
using NetworkConfigurator.Model;
using Newtonsoft.Json;
using System.IO; 

namespace NetworkConfigurator.Controllers
{
    public class SavedController : Controller
    {
        PeopleContext context;
        static SavedViewModel network;


       // SavedDataManager savedData;
        //Constructor initiates database context
        public SavedController(PeopleContext _context)
        {
            this.context = _context;
           // savedData = new SavedDataManager(this.context);
        }



        // /saved or /saved/index
        // this method shows the view with the list of all networks that are saved
        public IActionResult Index()
        {
            IList<SavedViewModel> networks = SavedDataManager.GetAllNetworks(context);

            return View(networks);
        }


        // Handles the /Detail/(id) route
        // queries the database for the network with the given id and returns it
        public  IActionResult Detail(int id)
        {
            network  = SavedDataManager.GetNetwork(context, id);

            return View("Detail", network);
        }


        // This method returns network data IN JSON format
        [HttpPost("Saved/GetNetworkFile")]
        public JsonResult GetNetworkFile()
        {
            //string net = JsonConvert.SerializeObject(SavedController.network);
            //return Content(net, "application/json");

            return Json(SavedController.network);
        }



    }
}