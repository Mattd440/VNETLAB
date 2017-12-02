/*
 * This Class Handles the Database Operations for the Create Page
 * 
 */

using System;
using NetworkConfigurator.DataManager;
using NetworkConfigurator.Model;
namespace NetworkConfigurator.DataManager
{
    
    public class CreateDataManager
    {
        PeopleContext context;

        //Constructor initializes the context
        public CreateDataManager(PeopleContext _context)
        {
            context = _context;
        }

        // Saves a network
        public void SaveNetwork(Network network)
		{
			context.Network.Add(network);
			context.SaveChanges();
		}

        //saves a host
		public static void SaveHost(PeopleContext context, Host host)
		{
			context.Hosts.Add(host);
			context.SaveChanges();
		}

        // saves a switch
		public static void SaveSwitch(PeopleContext context, Switch switch1)
		{
			context.Switchs.Add(switch1);
			context.SaveChanges();
		}
    }
}
