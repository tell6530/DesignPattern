using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.State
{
    public class AfternoonState : State
    {
        public AfternoonState(int clockHour)
        {
            this._clockHour = clockHour;
        }

        public override void Handle(StateContext stateContext)
        {
            if (this._clockHour >= 14 && this._clockHour < 19)
            {
                Console.WriteLine("Full of energy to work!!!");
            }
            else
            {
                stateContext._state = new NightState(this._clockHour);
                stateContext.Request();
            }
        }
    }
}
