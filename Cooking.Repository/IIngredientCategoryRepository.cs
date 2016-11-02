using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Repository
{
    public interface IIngredientCategoryRepository
    {
        bool Remove( int idIngredientCategory );
        bool Save( IngredientCategory ingredientCategory );
        IngredientCategory GetById( int idIngredientCategory );
        bool Update( IngredientCategory ingredientCategory );
        List<IngredientCategory> GetAll();
    }
}
