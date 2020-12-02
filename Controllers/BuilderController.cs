using DesignPattern.Builder;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BuilderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPastaRecipe()
        {
            var pastaRecipe = new PastaRecipe();
            var recipedirector = new NoodlesCuisineRecipeDirector(pastaRecipe);

            return this.Ok(recipedirector.GetNoodlesRecipe());
        }

        [HttpGet]
        public IActionResult GetDanDanNoodlesRecipe()
        {
            var danDanNoodles = new DanDanNoodlesRecipe();
            var recipedirector = new NoodlesCuisineRecipeDirector(danDanNoodles);

            return this.Ok(recipedirector.GetNoodlesRecipe());
        }
    }
}
