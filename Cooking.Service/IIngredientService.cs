using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Service
{
    public interface IIngredientService
    {
        bool Add( Ingredient i );
        List<Ingredient> Get();
        Ingredient Get( int id );
        bool Remove( int id );
    }
}
