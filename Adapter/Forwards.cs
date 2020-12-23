using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Adapter
{
    public class Forwards : Player
    {
        public Forwards(string name) : base(name)
        {

        }

        public override void Defend()
        {
            Console.WriteLine($"Defend, {this.name}!!!");
        }

        public override void Offend()
        {
            Console.WriteLine($"Offend, {this.name}!!!");
        }
    }
}
