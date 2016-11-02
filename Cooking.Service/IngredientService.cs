using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Cooking.Repository;

namespace Cooking.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepo;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public IngredientService( IIngredientRepository ingredientRepo, IRecipeIngredientService recipeIngredientService )
        {
            _ingredientRepo = ingredientRepo;
            _recipeIngredientService = recipeIngredientService;
        }

        public bool Add( Ingredient i )
        {
            return _ingredientRepo.Save( i );
        }

        public List<Ingredient> Get()
        {
            return _ingredientRepo.GetAll();
        }

        public Ingredient Get( int id )
        {
            return _ingredientRepo.GetById(id);
        }

        public bool Remove( int id )
        {
            return _ingredientRepo.Remove( id );
        }
    }
}
