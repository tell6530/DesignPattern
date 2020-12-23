using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Adapter
{
    public class Translator : Player
    {
        private ForeignerCenter _foreignerCenter = new ForeignerCenter();

        public Translator(string name) : base(name)
        {
            this._foreignerCenter.Name = name;
        }

        public override void Defend()
        {
            this._foreignerCenter.Defend();
        }

        public override void Offend()
        {
            this._foreignerCenter.Offend();
        }
    }
}
