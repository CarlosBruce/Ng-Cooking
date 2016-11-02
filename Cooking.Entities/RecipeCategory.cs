namespace Cooking.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecipeCategory
    {
        public RecipeCategory()
        {
            this.Recipes = new List<Recipe>();
        }
    
        public int IdRecipeCategory { get; set; }
        public string Name { get; set; }
    
        public virtual List<Recipe> Recipes { get; set; }
    }
}
