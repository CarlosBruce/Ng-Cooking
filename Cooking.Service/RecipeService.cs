using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Cooking.Repository;

namespace Cooking.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepo;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeService( IRecipeRepository recipeRepo , IRecipeIngredientService recipeIngredientService )
        {
            _recipeRepo = recipeRepo;
            _recipeIngredientService = recipeIngredientService;
        }
        public bool Add( Recipe r )
        {
            if( r.Ingredients.Count > 0 && r.Ingredients.Count <= 10 && r.IdRecipeCategory > 0 && r.IdUser > 0 )
            {
                if( _recipeRepo.Save( r ) )
                {
                    List<RecipeIngredient> rc = new List<RecipeIngredient>();

                    foreach( Ingredient i in r.Ingredients )
                        rc.Add( new RecipeIngredient() { IdIngredient = i.IdIngredient, IdRecipe = r.IdRecipe } );

                    return _recipeIngredientService.Add( rc );
                }

            }

            return false;
        }

        public List<Recipe> Get()
        {
            return _recipeRepo.GetAll(  );
        }

        public Recipe Get( int id )
        {
            return _recipeRepo.GetById(id);
        }

        public bool Remove( int id )
        {
            return _recipeRepo.Remove( id );
        }
    }
}
