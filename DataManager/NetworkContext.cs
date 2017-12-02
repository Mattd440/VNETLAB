/*
 * This class handles the database and table creation
 * 
 */


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
        // Creates the Network Table
        public DbSet<Network> Network { get; set; }
       
        // Creates the Host Table
        public DbSet<Host> Hosts { get; set; }

        // Creates the Switch Table
        public DbSet<Switch> Switchs { get; set; }
      
        // Setsup the database Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Server=tcp:vnet2.database.windows.net,1433;Initial Catalog=VNET2-sql;Persist Security Info=False;User ID=mattd440;Password=Mmd44035;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Persist Security Info=True; ");
        }

        //required empty intializers
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {

        }
        public PeopleContext() { }

        // queries for a switchs ID
        public int getSwitchID(string name)
        {
            var net = this.Network; ;
            var id = from s in Network
                     from sw in s.Switchs
                     where sw.Name == name
                     select sw.ID ;
            return id.First() ; 
        }
       
        // queries for a networks ID
        public int getNetworkId(string name)
        {
            var id = from n in Network
                      where n.Name == name
                      select n.ID;
            return id.First();

        }
    }
}
