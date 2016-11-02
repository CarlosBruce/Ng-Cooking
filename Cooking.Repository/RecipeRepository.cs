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
    public class RecipeRepository : IRecipeRepository
    {
        private string _dbConnection;

        private SqlConnection GetConnection()
        {
            //return new SqlConnection( ConfigurationManager.ConnectionStrings["DBConnection"].ToString() );

            return new SqlConnection( this._dbConnection );
        }

        public RecipeRepository()
        {
            this._dbConnection = "Server=DESKTOP-LI1BB0E;Database=Cooking;Trusted_Connection=True;";

        }

        private List<RecipeRate> getRecipeRates( int idRecipe )
        {
            List<Entities.RecipeRate> recipesRates = new List<Entities.RecipeRate>();
            var param = new DynamicParameters();
            param.Add( "@IdRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipesRates = connection.Query<Entities.RecipeRate, Entities.User, Entities.RecipeRate>( "PS_SELECT_ALL_COMPLETE_RecipeRate_BY_Recipe_ID",
                ( rt,  u ) =>
                {
                    u.IdUser = rt.IdUser;

                    rt.User = u;
                    return rt;
                }, splitOn: "UserIdUser",param: param
                , commandType: CommandType.StoredProcedure ).ToList();
            }


            return recipesRates;
        }

        public List<Recipe> GetAll()
        {
            List<Entities.Recipe> recipes = new List<Entities.Recipe>();

            using( SqlConnection connection = GetConnection() )
            {
                recipes = connection.Query<Entities.Recipe>( "PS_SELECT_ALL_Recipe", commandType: CommandType.StoredProcedure ).ToList();


                recipes = connection.Query<Entities.Recipe, Entities.RecipeCategory, Entities.User, Entities.Recipe>( "PS_SELECT_ALL_COMPLETE_Recipe",
                ( r, rc,u ) =>
                {
                    rc.IdRecipeCategory = r.IdRecipeCategory;
                    u.IdUser = r.IdUser;

                    r.User = u;
                    r.RecipeCategory = rc;
                    r.Ingredients = getAllIngredientsByRecipeId(r.IdRecipe);
                    return r;
                }, splitOn: "RecipeCategoryIdRecipeCategory,UserIdUser"
                , commandType: CommandType.StoredProcedure ).ToList();



            }

            foreach (Recipe r in recipes)
                r.RecipeRates = getRecipeRates( r.IdRecipe );

            return recipes;
        }

        private ICollection<Ingredient> getAllIngredientsByRecipeId( int idRecipe )
        {
            List<Entities.Ingredient> recipeIngredients = new List<Entities.Ingredient>();
            var param = new DynamicParameters();
            param.Add( "@IdRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipeIngredients = connection.Query<Entities.Ingredient>
                    ( "PS_SELECT_ALL_Ingredient_BY_RecipeID",  commandType: CommandType.StoredProcedure, param: param ).ToList();
            }
            return recipeIngredients;
        }

        public Recipe GetById( int idRecipe )
        {
            Entities.Recipe recipe = new Entities.Recipe();
            var param = new DynamicParameters();
            param.Add( "@IdRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );
            using( SqlConnection connection = GetConnection() )
            {
                recipe = connection.Query<Entities.Recipe, Entities.RecipeCategory, Entities.User, Entities.Recipe>( "PS_SELECT_ALL_COMPLETE_Recipe_BY_ID",
                            ( r, rc, u ) =>
                            {
                                rc.IdRecipeCategory = r.IdRecipeCategory;
                                u.IdUser = r.IdUser;
                                r.Ingredients = getAllIngredientsByRecipeId( r.IdRecipe );
                                r.RelatedRecipes = getAllRelatedRecipesByRecipeId( r.IdRecipe );
                                foreach(Recipe _recipe in r.RelatedRecipes)
                                    _recipe.RecipeRates = getRecipeRates( _recipe.IdRecipe );
                                r.User = u;
                                r.RecipeCategory = rc;
                                return r;
                            }, splitOn: "RecipeCategoryIdRecipeCategory,UserIdUser"
                            , commandType: CommandType.StoredProcedure, param: param ).FirstOrDefault();

            }

            recipe.RecipeRates = getRecipeRates( recipe.IdRecipe );
            return recipe;
        }

        private ICollection<Recipe> getAllRelatedRecipesByRecipeId( int idRecipe )
        {
            List<Entities.Recipe> recipes = new List<Entities.Recipe>();
            var param = new DynamicParameters();
            param.Add( "@IdRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipes = connection.Query<Entities.Recipe>
                    ( "PS_SELECT_ALL_RelatedRecipes_BY_RecipeID", commandType: CommandType.StoredProcedure, param: param ).ToList();
            }
            return recipes;
        }

        public bool Remove( int idRecipe )
        {
            var param = new DynamicParameters();
            param.Add( "@idRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_Delete_Recipe", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Save( Recipe recipe )
        {
            int rvalue = -1;

            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    recipe.CreationDate = DateTime.Now;
                    rvalue = connection.Query<int>( "PS_INSERT_Recipe", new {recipe.Preparation, recipe.CreationDate ,recipe.IdRecipeCategory,recipe.IdUser,recipe.Name,recipe.UrlRecipePicture}, commandType: CommandType.StoredProcedure ).FirstOrDefault();
                }
                if( rvalue == -1 )
                    return false;
                else
                    recipe.IdRecipe = rvalue;
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Update( Recipe recipe )
        {
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_UPDATE_Recipe", new { recipe.IdRecipe, recipe.Preparation, recipe.IdRecipeCategory, recipe.IdUser, recipe.Name, recipe.UrlRecipePicture }, commandType: CommandType.StoredProcedure );
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
