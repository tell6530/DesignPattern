using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.State
{
    public class NightState : State
    {
        public NightState(int clockHour)
        {
            this._clockHour = clockHour;
        }

        public override void Handle(StateContext stateContext)
        {
            if (this._clockHour >= 19)
            {
                Console.WriteLine("Self-owned space!!!");
            }
        }
    }
}
