using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.State
{
    public class MorningState : State
    {
        public MorningState(int clockHour)
        {
            this._clockHour = clockHour;
        }

        public override void Handle(StateContext stateContext)
        {
            if (this._clockHour < 12)
            {
                Console.WriteLine("A lot of meetings to attend!");
            }
            else
            {
                stateContext._state = new NoonState(this._clockHour);
                stateContext.Request();
            }
        }
    }
}
