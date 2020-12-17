using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.State
{
    public class NoonState : State
    {
        public NoonState(int clockHour)
        {
            this._clockHour = clockHour;
        }

        public override void Handle(StateContext stateContext)
        {
            if (this._clockHour >= 12 && this._clockHour < 14)
            {
                Console.WriteLine("It's a really hungry and sleepy time");
            }
            else
            {
                stateContext._state = new AfternoonState(this._clockHour);
                stateContext.Request();
            }
        }
    }
}
