using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Service
{
    public interface IRecipeIngredientService
    {
        bool Add( List<RecipeIngredient> recipeIngredients );
        List<RecipeIngredient> GetByIngredientId( int id );
        List<RecipeIngredient> GetByRecipeId( int id );
        bool Remove( int idIngredient, int idRecipe );
        bool RemovedIngredient( int idIngredient);
        bool RemovedRecipe(int idRecipe );
    }
}
