namespace DesignPattern.Builder
{
    public class DanDanNoodlesRecipe : NoodlesCuisineRecipeBuilder
    {
        public override void CookNoodles()
        {
            base.recipe.AppendLine("Step1:");
            base.recipe.AppendLine("Add you mian.");
        }

        public override void AddSauce()
        {
            base.recipe.AppendLine("Step2:");
            base.recipe.AppendLine("Add rou zao and eag.");
        }
    }
}
