using DesignPattern.Adapter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("(controller)/(action)")]
    public class AdapterController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOffendStrategy()
        {
            Player jordan = new Forwards("Jordan");
            jordan.Offend();

            Player susu = new Forwards("Jung Hao, Su");
            susu.Offend();

            return this.Ok();
        }
    }
}
