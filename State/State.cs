using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.State
{
    public abstract class State
    {
        protected int _clockHour;

        public abstract void Handle(StateContext stateContext);
    }
}
