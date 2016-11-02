namespace Cooking.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngredientCategory
    {
        public IngredientCategory()
        {
            this.Ingredients = new List<Ingredient>();
        }
    
        public int IdIngredientCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual List<Ingredient> Ingredients { get; set; }
    }
}
