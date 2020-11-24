using DesignPattern.Observer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ObserverController : ControllerBase
    {
        [HttpGet]
        public IActionResult POTaskStatement()
        {
            Subject POSubject = new POSubject("Stacy");

            POSubject.Attach(new HardWorkerObserver(POSubject, "susu", "Ok! I will do it!"));
            POSubject.Attach(new NormalObserver(POSubject, "Don Xiao Jie", "..., What did you say?"));

            return this.Ok(POSubject.NotifyTask());
        }

        [HttpGet]
        public IActionResult TechLeadTaskStatement()
        {
            Subject techLeadSubject = new TechLeadSubject("Jerome");

            techLeadSubject.Attach(new HardWorkerObserver(techLeadSubject, "susu", "I already Planned it all!"));
            techLeadSubject.Attach(new NormalObserver(techLeadSubject, "Don Xiao Jie", "Ok! I will do it!"));
            techLeadSubject.Attach(new LazyBoneObserver(techLeadSubject, "Han Yi mei mei", "But I want to sleep!!!"));

            return this.Ok(techLeadSubject.NotifyTask());
        }
    }
}
