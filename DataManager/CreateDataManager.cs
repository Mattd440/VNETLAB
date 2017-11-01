using System;
using NetworkConfigurator.DataManager;
using NetworkConfigurator.Model;
namespace NetworkConfigurator.DataManager
{
    public class CreateDataManager
    {
        PeopleContext context;

        public CreateDataManager(PeopleContext _context)
        {
            context = _context;
        }


        public void SaveNetwork(Network network)
		{
			context.Network.Add(network);
			context.SaveChanges();
		}


		public static void SaveHost(PeopleContext context, Host host)
		{
			context.Hosts.Add(host);
			context.SaveChanges();
		}

		public static void SaveSwitch(PeopleContext context, Switch switch1)
		{
			context.Switchs.Add(switch1);
			context.SaveChanges();
		}
    }
}
