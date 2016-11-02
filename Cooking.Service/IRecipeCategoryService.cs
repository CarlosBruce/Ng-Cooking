using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Service
{
    public  interface IRecipeCategoryService
    {
        bool Add( RecipeCategory rc );
        List<RecipeCategory> Get();
        RecipeCategory Get( int id );
        bool Remove( int id );
    }
}
