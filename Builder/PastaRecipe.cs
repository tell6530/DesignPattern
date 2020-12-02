namespace DesignPattern.Builder
{
    public class PastaRecipe : NoodlesCuisineRecipeBuilder
    {
        public override void CookNoodles()
        {
            base.recipe.AppendLine("Step1:");
            base.recipe.AppendLine("Add spaghetti.");
        }

        public override void AddSauce()
        {
            base.recipe.AppendLine("Step2:");
            base.recipe.AppendLine("Add pasta sauce.");
        }
    }
}
