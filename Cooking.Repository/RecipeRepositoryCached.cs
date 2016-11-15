using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Enyim.Caching;

namespace Cooking.Repository
{
    public class RecipeRepositoryCached : IRecipeRepository
    {
        public List<Recipe> GetAll()
        {
            List<Recipe> recipes = new List<Recipe>();
            RecipeRepository rc = new RecipeRepository();

            using (MemcachedClient client = new MemcachedClient())
            {
                recipes = client.Get<List<Recipe>>("Recipes");
                if (recipes.Count == 0)
                {
                    recipes = rc.GetAll();
                    client.Store(Enyim.Caching.Memcached.StoreMode.Set, "Recipes", recipes);
                }
            }

            return recipes;
        }

        public Recipe GetById(int idRecipe)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int idRecipe)
        {
            throw new NotImplementedException();
        }

        public bool Save(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public bool Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
