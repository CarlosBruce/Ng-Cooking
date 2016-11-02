using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Repository
{
    public interface IIngredientRepository
    {
        bool Remove( int idIngredient);
        bool Save( Ingredient   ingredient );
        Ingredient GetById( int idIngredient );
        bool Update( Ingredient ingredient );
        List<Ingredient> GetAll();
    }
}
