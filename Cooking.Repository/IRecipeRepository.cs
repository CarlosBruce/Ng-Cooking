using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Repository
{
    public interface IRecipeRepository
    {
        bool Remove( int idRecipe );
        bool Save( Recipe recipe );
        Recipe GetById( int idRecipe );
        bool Update( Recipe recipe );
        List<Recipe> GetAll();
    }
}
