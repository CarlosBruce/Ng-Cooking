using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Cooking.Repository;

namespace Cooking.Service
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientrepo;

        public RecipeIngredientService( IRecipeIngredientRepository recipeIngredientrepo )
        {
            _recipeIngredientrepo = recipeIngredientrepo;
        }

        public bool Add( List<RecipeIngredient> recipeIngredients )
        {
           return _recipeIngredientrepo.Save(recipeIngredients);
        }

        public List<RecipeIngredient> GetByIngredientId( int id )
        {
            return _recipeIngredientrepo.GetAllByIngredient( id );
        }

        public List<RecipeIngredient> GetByRecipeId( int id )
        {
            return _recipeIngredientrepo.GetAllByRecipe( id );
        }

        public bool Remove( int idIngredient, int idRecipe )
        {
            return _recipeIngredientrepo.Remove( idIngredient, idRecipe );
        }

        public bool RemovedIngredient( int idIngredient )
        {
            return _recipeIngredientrepo.RemoveRecipesWithIngredient( idIngredient);
        }

        public bool RemovedRecipe( int idRecipe )
        {
            return _recipeIngredientrepo.RemoveIngredientsinRecipe(idRecipe );
        }
    }
}
