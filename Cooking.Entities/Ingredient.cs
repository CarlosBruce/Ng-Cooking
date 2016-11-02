namespace Cooking.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<Recipe>();
        }
    
        public int IdIngredient { get; set; }
        public string Name { get; set; }
        public decimal Calories { get; set; }
        public int IdIngredientCategory { get; set; }


        public string UrlIngredientPicture { get; set; }

        public virtual IngredientCategory IngredientCategory { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
