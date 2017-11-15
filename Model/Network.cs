using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkConfigurator.Model
{
    public class Network
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Host> Hosts { get; set; }
        public ICollection<Switch> Switchs { get; set; }

        public Network()
        {

        }
        public Network(String Name){
            this.Name = Name;

        }
    }
}
