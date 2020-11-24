using DesignPattern.Facade;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacadeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSystemMessage()
        {
            var facade = new SystemFacade();

            return this.Ok(facade.GetSystemMessage());
        }
    }
}
