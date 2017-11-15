using Microsoft.EntityFrameworkCore;
using NetworkConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetworkConfigurator.DataManager;
namespace NetworkConfigurator.DataManager
{

    // this class is used for datebase access and CRUD operations
    public class PeopleContext :DbContext
    {

        public DbSet<Network> Network { get; set; }
       //public DbSet<Person> people { get; set; }
     
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Switch> Switchs { get; set; }
       // public DbSet<Switch> switchs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=VNET;Integrated Security=True;");
            // optionsBuilder.UseSqlServer("Server=tcp:viewnet2.database.windows.net,1433;Initial Catalog=viewnet2;Persist Security Info=False;User ID=webappuser;Password=Mmd44035;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Persist Security Info=True;");
            optionsBuilder.UseSqlServer("Server=tcp:vnet2.database.windows.net,1433;Initial Catalog=VNET2-sql;Persist Security Info=False;User ID=mattd440;Password=Mmd44035;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Persist Security Info=True; ");
        }

        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {

        }
        public PeopleContext() { }

        public int getSwitchID(string name)
        {
            var net = this.Network; ;
            var id = from s in Network
                     from sw in s.Switchs
                     where sw.Name == name
                     select sw.ID ;
            return id.First() ; 
        }
       
        public int getNetworkId(string name)
        {
            var id = from n in Network
                      where n.Name == name
                      select n.ID;
            return id.First();

        }
    }
}
