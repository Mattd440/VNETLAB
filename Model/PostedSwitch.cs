/*
 * MODEL for the Data recieved when a switch is saved on the create page
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkConfigurator.Model
{
    public class PostedSwitch
    {
        public string name { get; set; }
        public string eth0 { get; set; }
        public int ports { get; set; }

    }
}
