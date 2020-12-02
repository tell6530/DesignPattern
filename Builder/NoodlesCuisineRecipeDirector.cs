namespace DesignPattern.Builder
{
    public class NoodlesCuisineRecipeDirector
    {
        private NoodlesCuisineRecipeBuilder _noodlesRecipeBuilder;

        public NoodlesCuisineRecipeDirector(NoodlesCuisineRecipeBuilder noodlesRecipeBuilder)
        {
            this._noodlesRecipeBuilder = noodlesRecipeBuilder;
        }

        public string GetNoodlesRecipe()
        {
            this._noodlesRecipeBuilder.CookNoodles();
            this._noodlesRecipeBuilder.AddSauce();

            return this._noodlesRecipeBuilder.GetRecipe();
        }
    }
}
