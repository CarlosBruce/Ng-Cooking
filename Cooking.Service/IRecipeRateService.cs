using Cooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Service
{
    public interface IRecipeRateService
    {
        bool Add( RecipeRate rtrc );
    }
}
