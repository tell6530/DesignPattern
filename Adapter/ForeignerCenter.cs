using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Adapter
{
    public class ForeignerCenter
    {
        public string Name { get; set; }

        public void Defend()
        {
            Console.WriteLine($"Defend, {this.Name}!!!");
        }

        public void Offend()
        {
            Console.WriteLine($"Offend, {this.Name}!!!");
        }
    }
}
