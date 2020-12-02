using System.Text;

namespace DesignPattern.Builder
{
    public abstract class NoodlesCuisineRecipeBuilder
    {
        protected StringBuilder recipe = new StringBuilder();

        public abstract void CookNoodles();

        public abstract void AddSauce();

        public string GetRecipe()
        {
            recipe.Append("Finish!");
            return recipe.ToString();
        }
    }
}
