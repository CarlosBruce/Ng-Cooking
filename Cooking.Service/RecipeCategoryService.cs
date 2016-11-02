using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Cooking.Repository;

namespace Cooking.Service
{
    public class RecipeCategoryService : IRecipeCategoryService
    {
        private readonly IRecipeCategoryRepository _recipeCategoryServiceRepo;

        public RecipeCategoryService( IRecipeCategoryRepository recipeCategoryServiceRepo )
        {
            _recipeCategoryServiceRepo = recipeCategoryServiceRepo;
        }

        public bool Add( RecipeCategory rc )
        {
            return _recipeCategoryServiceRepo.Save( rc );
        }

        public List<RecipeCategory> Get()
        {
            return _recipeCategoryServiceRepo.GetAll();
        }

        public RecipeCategory Get( int id )
        {
            return _recipeCategoryServiceRepo.GetById(id);
        }

        public bool Remove( int id )
        {
            return _recipeCategoryServiceRepo.Remove( id );
        }
    }
}
