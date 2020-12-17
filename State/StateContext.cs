using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.State
{
    public class StateContext
    {
        public State _state { get; set; }

        public StateContext(State state)
        {
            this._state = state;
        }

        public void Request()
        {
            this._state.Handle(this);
        }
    }
}
