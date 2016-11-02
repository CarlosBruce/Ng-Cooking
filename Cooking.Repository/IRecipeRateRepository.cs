using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Repository
{
    public interface IRecipeRateRepository
    {
        //bool Remove( int idRecipeRate );
        bool Save( RecipeRate recipeRate );
        //RecipeRate GetById( int idRecipeRate );
        //bool Update( RecipeRate recipeRate );
        //List<RecipeRate> GetAll();
    }
}
