﻿/*
 * Class Controlls The database operations For the Saved Page
 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkConfigurator.Model;
using Newtonsoft.Json;

namespace NetworkConfigurator.DataManager
{
    public static class SavedDataManager
    {
        // returns the number of networks saved in the databse
        public static int GetNumNetworks(PeopleContext context)
        {
            var num = from n in context.Network
                      select n;
            return num.Count();
        }

        // returns the network with the passed in ID
        public static SavedViewModel GetNetwork(PeopleContext context, int id)
        {
            int ID = context.Network.Where(x => x.ID == id).Select(x => x.ID).First();
            //int ID = network.ID;
            string name = context.Network.Where(x => x.ID == id).Select(x => x.Name).First();
            var hosts = context.Hosts.Where(x => x.NetworkID == ID).Select(x => x).ToList();
            var switchs = context.Switchs.Where(x => x.NetworkID == ID).Select(x => x).ToList();

            var svm = new SavedViewModel()
            {
                Network = new Network() { ID = ID, Name = name },
                Hosts = hosts,
                Switchs = switchs,
            };
           

            return svm;
        }

        // returns all Network Objects saved in the database
        public static List<SavedViewModel> GetAllNetworks(PeopleContext context)
        {
            List<SavedViewModel> svm = new List<SavedViewModel>();
            for (int i = 106; i < SavedDataManager.GetNumNetworks(context) + 106; i++)
            {
                SavedViewModel viewModel = SavedDataManager.GetNetwork(context, i);
                svm.Add(viewModel);
            }
            return svm;
        }

        // 
		//public static FileStreamResult DownloadFile(SavedViewModel network)
		//{
		//	var location = "NetworkConfigurator.File";
		//	if (network != null)
		//	{

		//		System.IO.File.WriteAllText(location + "/mynetwork.json", JsonConvert.SerializeObject(network));
		//		Stream str = System.IO.File.OpenRead(location + "/mynetwork.json");
		//		return new FileStreamResult(str, Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json"));
		//	}
		//	return null;
		//}
    }
}
