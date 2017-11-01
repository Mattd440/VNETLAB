using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
namespace NetworkConfigurator.Model
{
    public class Person
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public Person() { }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
    }
}
