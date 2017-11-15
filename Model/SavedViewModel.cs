using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkConfigurator.Model
{
    public class SavedViewModel
    {
        public Network Network { get; set; }
        public IEnumerable<Host> Hosts { get; set; }
         public IEnumerable<Switch> Switchs { get; set; }

        public SavedViewModel()
        {

        }
        public SavedViewModel(Network net)
        {
            this.Network = net;
        }
    }
}
