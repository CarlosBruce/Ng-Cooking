using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Repository
{
    public interface IRecipeIngredientRepository
    {

        bool RemoveRecipesWithIngredient( int idIngredient );


        bool Remove( int idIngredient , int idRecipe );

        bool RemoveIngredientsinRecipe( int idRecipe );

        bool Save( List<RecipeIngredient> recipeIngredients );

        List<RecipeIngredient> GetAllByRecipe( int idRecipe );

        List<RecipeIngredient> GetAllByIngredient( int idIngredient );
    }
}
