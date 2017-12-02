/*
 * This Class Controls The Page to Create Networks 
 * Index Method Displays the page that allows you to create networks
 * The add host/switch/network are HTTP POST end points that allow you to send
*data that will be processed and saved to the database
*
*The URLS they handle are noted above each method
*
*/ 




using Microsoft.AspNetCore.Mvc;
using NetworkConfigurator.DataManager;
using NetworkConfigurator.Model;
using Microsoft.AspNetCore.Cors;

// create a save button that passes an instance of a network back to index and save the network to a list of networks in index
namespace NetworkConfigurator.Controllers
{
    //handles all /create urls
    public class CreateController : Controller
    {
        //used for post request to add new components
        public PeopleContext _context;
        public Host newHost;
        public Switch newSwitch;
        public Network newNetwork;
        public CreateDataManager createDM;
       
        static string   NetworkName; 
       
        // Contstruct creates the database context that is used to connect with
        // database to add/ delete update data 
        // also creates an instance of the datamanager and the context is passed to it
        public CreateController(PeopleContext context)
        {
            createDM = new CreateDataManager(context);
            this._context = context;

        }
       
        //  /create or /create/index  returns the view in the views/create folder
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost("Create/AddNetwork")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddNetwork([FromBody]string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
               
                NetworkName = name; 
                this.newNetwork = new Network();
                this.newNetwork.Name = name;
              
                createDM.SaveNetwork(this.newNetwork);
                
            }

            return RedirectToAction("Index");
        }



        //  /create/addhost 
        // used on post request to add a new host
        [HttpPost("Create/AddNewHost")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddNewHost([FromBody]PostedHost host)
        {
          
            this.newHost = new Host();
           this.newHost.Name = host.name;
          this.newHost.Adapter = host.eth0;
            newHost.SwitchID = _context.getSwitchID(host.switchName) ;
             this.newHost.NetworkID = _context.getNetworkId(NetworkName);

            CreateDataManager.SaveHost(_context, this.newHost);


            return RedirectToAction("Index");
        }



        // /create/addswitch
        [HttpPost("Create/AddNewSwitch")]
         [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddNewSwitch([FromBody] PostedSwitch switch1)
        {
            this.newSwitch = new Switch();
            this.newSwitch.Name = switch1.name;
            this.newSwitch.Adapter = switch1.eth0;
            this.newSwitch.ports = switch1.ports;
            this.newSwitch.NetworkID = _context.getNetworkId(NetworkName);

            CreateDataManager.SaveSwitch(_context, this.newSwitch); 

            return RedirectToAction("Index");
        }

    }
}