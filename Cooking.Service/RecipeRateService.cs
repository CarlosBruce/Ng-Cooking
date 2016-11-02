using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Cooking.Repository;

namespace Cooking.Service
{
    public class RecipeRateService : IRecipeRateService
    {
        private readonly IRecipeRateRepository _recipeRateRepo;

        public RecipeRateService( IRecipeRateRepository recipeRateRepo )
        {
            _recipeRateRepo = recipeRateRepo;
        }

        public bool Add( RecipeRate rt )
        {
            return _recipeRateRepo.Save( rt );
        }
    }
}
