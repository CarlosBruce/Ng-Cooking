using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;

namespace Cooking.Repository
{
    public interface IRecipeCategoryRepository
    {
        bool Remove( int idIngredientCategory );
        bool Save( RecipeCategory ingredientCategory );
        RecipeCategory GetById( int idIngredientCategory );
        bool Update( RecipeCategory ingredientCategory );
        List<RecipeCategory> GetAll();
    }
}
