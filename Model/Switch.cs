/*
 * MODEL for the SWITCH table
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkConfigurator.Model
{
    [Table("Switch")]
    public class Switch 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adapter { get; set; }
        public int ports { get; set; }
        public int? NetworkID { get; set; }
        public ICollection<Host> connectedHosts { get; set; }

        public Switch()
        {

        }
        public Switch(String Name, String Adapter, int ports)
        {
            this.Name = Name;
            this.Adapter = Adapter;
            this.ports = ports;
           
        }
    }
}
