using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Cooking.Repository
{
    public class RecipeCategoryRepository : IRecipeCategoryRepository
    {
        private string _dbConnection;

        private SqlConnection GetConnection()
        {
            //return new SqlConnection( ConfigurationManager.ConnectionStrings["DBConnection"].ToString() );

            return new SqlConnection( this._dbConnection );
        }

        public RecipeCategoryRepository()
        {
            this._dbConnection = "Server=DESKTOP-LI1BB0E;Database=Cooking;Trusted_Connection=True;";


        }
        public List<RecipeCategory> GetAll()
        {
            List<Entities.RecipeCategory> recipesCat = new List<Entities.RecipeCategory>();

            using( SqlConnection connection = GetConnection() )
            {
                recipesCat = connection.Query<Entities.RecipeCategory>( "PS_SELECT_ALL_RecipeCategory", commandType: CommandType.StoredProcedure ).ToList();
            }
            foreach( Entities.RecipeCategory rc in recipesCat )
                GetallRecipes( rc );

            return recipesCat;
        }

        private void GetallRecipes( RecipeCategory recipeCategory )
        {
            Entities.IngredientCategory ingredientcat = new Entities.IngredientCategory();
            var param = new DynamicParameters();
            param.Add( "@IdRecipeCategory", dbType: DbType.Int32, value: recipeCategory.IdRecipeCategory, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipeCategory.Recipes.AddRange( connection.Query<Entities.Recipe>( "PS_SELECT_ALL_Recipes_BY_CategoryID", commandType: CommandType.StoredProcedure, param: param ).ToList() );
            }
        }

        public RecipeCategory GetById( int idRecipeCategory )
        {
            Entities.RecipeCategory recipecat = new Entities.RecipeCategory();
            var param = new DynamicParameters();
            param.Add( "@IdRecipeCategory", dbType: DbType.Int32, value: idRecipeCategory, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipecat = connection.Query<Entities.RecipeCategory>( "PS_SELECT_ALL_RecipeCategory_BY_ID", commandType: CommandType.StoredProcedure, param: param ).FirstOrDefault();
            }

            GetallRecipes( recipecat );
            return recipecat;
        }

        public bool Remove( int idRecipeCategory )
        {
            var param = new DynamicParameters();
            param.Add( "@IdRecipeCategory", dbType: DbType.Int32, value: idRecipeCategory, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_Delete_RecipeCategory", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Save( RecipeCategory recipeCategory )
        {
            int rvalue = -1;

            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    rvalue = connection.Query<int>( "PS_INSERT_RecipeCategory", new { recipeCategory.Name }, commandType: CommandType.StoredProcedure ).FirstOrDefault();
                }
                if( rvalue == -1 )
                    return false;
                else
                    recipeCategory.IdRecipeCategory = rvalue;
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Update( RecipeCategory recipeCategory )
        {
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_UPDATE_RecipeCategory", new { recipeCategory.Name, recipeCategory.IdRecipeCategory }, commandType: CommandType.StoredProcedure );
                }
            }
            catch( SqlException e )
            {
                return false;
                throw e;
            }
            return true;
        }
    }
}
