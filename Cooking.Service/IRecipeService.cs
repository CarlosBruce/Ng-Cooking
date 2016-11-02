using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Service
{
    public  interface IRecipeService
    {
        bool Add( Recipe r );
        List<Recipe> Get();
        Recipe Get( int id );
        bool Remove( int id );
    }
}
