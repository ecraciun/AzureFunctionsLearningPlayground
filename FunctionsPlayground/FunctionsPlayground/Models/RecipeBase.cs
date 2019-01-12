using System;
using System.Collections.Generic;

namespace FunctionsPlayground.Models
{
    public abstract class RecipeBase
    {
        public abstract RestaurantRecipes RecipeType { get; }

        public abstract IEnumerable<Action> GetOrderedRecipeSteps();
    }
}