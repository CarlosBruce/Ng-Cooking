using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Entities
{
    public class RecipeIngredient
    {
        public int IdRecipe { get; set; }

        public int IdIngredient { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual Ingredient Ingredient { get; set; }

    }
}
