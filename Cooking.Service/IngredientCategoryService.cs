using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Cooking.Repository;

namespace Cooking.Service
{
    public class IngredientCategoryService : IIngredientCategoryService
    {
        private readonly IIngredientCategoryRepository _ingredientCategoryRepo;

        public IngredientCategoryService( IIngredientCategoryRepository ingredientCategoryRepo )
        {
            _ingredientCategoryRepo = ingredientCategoryRepo;
        }

        public bool Add( IngredientCategory ic )
        {
            return _ingredientCategoryRepo.Save(ic);
        }

        public List<IngredientCategory> Get()
        {
            return _ingredientCategoryRepo.GetAll();
        }

        public IngredientCategory Get( int id )
        {
            return _ingredientCategoryRepo.GetById( id );
        }

        public bool Remove( int id )
        {
            return _ingredientCategoryRepo.Remove( id );
        }
    }
}
