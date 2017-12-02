/*
 * 
 * MODEL for the Host Table
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkConfigurator.Model
{
    
    [Table("Hosts")]
    public class Host 
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Adapter { get; set; }
        public int? SwitchID { get; set; }
        public int? NetworkID { get; set; }
        public virtual Switch Switch { get; set; }
        public virtual Network Network { get; set; }

        public Host()
        {

        }
        public Host(String Name, String Adapter)
        {
            this.Name = Name;
            this.Adapter = Adapter;
        }

    }
}
