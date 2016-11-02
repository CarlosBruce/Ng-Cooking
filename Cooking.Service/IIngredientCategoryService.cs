using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Service
{
    public interface IIngredientCategoryService
    {
        bool Add( IngredientCategory ic );
        List<IngredientCategory> Get();
        IngredientCategory Get( int id );
        bool Remove( int id );
    }
}
