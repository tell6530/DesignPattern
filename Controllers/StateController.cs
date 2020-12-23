using DesignPattern.State;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StateController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetState(int clockHour)
        {
            var stateContext = new StateContext(new MorningState(clockHour));

            stateContext.Request();

            return this.Ok();
        }
    }
}
