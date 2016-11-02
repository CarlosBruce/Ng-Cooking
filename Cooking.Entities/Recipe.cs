namespace Cooking.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        public Recipe()
        {
            this.RecipeRates = new HashSet<RecipeRate>();
            this.Ingredients = new HashSet<Ingredient>();
        }
    
        public int IdRecipe { get; set; }
        public int IdRecipeCategory { get; set; }
        public string UrlRecipePicture { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }


        public string Preparation { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual RecipeCategory RecipeCategory { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<RecipeRate> RecipeRates { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
