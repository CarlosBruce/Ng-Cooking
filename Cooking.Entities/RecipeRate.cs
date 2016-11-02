namespace Cooking.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecipeRate
    {
        public int IdRecipe { get; set; }
        public decimal Rate { get; set; }
        public int IdUser { get; set; }

        public string Comment { get; set; }

        public string Title { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
