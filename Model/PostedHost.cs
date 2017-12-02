/*
 * MODEL for the Data recieved when a host is saved on the create page
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkConfigurator.Model
{
   public class PostedHost
    {
         public string name { get; set; }
        public string eth0 { get; set; }
     
        public string switchName { get; set; }

    }
}
