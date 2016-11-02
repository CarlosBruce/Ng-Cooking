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
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private string _dbConnection;

        private SqlConnection GetConnection()
        {
            //return new SqlConnection( ConfigurationManager.ConnectionStrings["DBConnection"].ToString() );

            return new SqlConnection( this._dbConnection );
        }

        public RecipeIngredientRepository()
        {
            this._dbConnection = "Server=DESKTOP-LI1BB0E;Database=Cooking;Trusted_Connection=True;";

        }

        public List<RecipeIngredient> GetAllByIngredient( int idIngredient )
        {
            List<Entities.RecipeIngredient> recipeIngredient = new List<Entities.RecipeIngredient>();
            var param = new DynamicParameters();
            param.Add( "@IdIngredient", dbType: DbType.Int32, value: idIngredient, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipeIngredient = connection.Query<Entities.RecipeIngredient, Entities.Ingredient, Entities.Recipe, Entities.RecipeIngredient>
                    ( "PS_SELECT_ALL_COMPLETE_RecipeIngredient_BY_Ingredient_ID",
                    ( ri, i,r ) =>
                    {
                        i.IdIngredientCategory = ri.IdIngredient;
                        r.IdRecipe = ri.IdRecipe;
                        ri.Recipe = r;
                        ri.Ingredient = i;
                        return ri;
                    }, splitOn: "IngredientIdIngredient,RecipeIdRecipe"
                    , commandType: CommandType.StoredProcedure, param: param ).ToList();
            }
            return recipeIngredient;
        }

        public List<RecipeIngredient> GetAllByRecipe( int idRecipe )
        {
            List<Entities.RecipeIngredient> recipeIngredient = new List<Entities.RecipeIngredient>();
            var param = new DynamicParameters();
            param.Add( "@IdRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipeIngredient = connection.Query<Entities.RecipeIngredient, Entities.Ingredient, Entities.Recipe, Entities.RecipeIngredient>
                    ( "PS_SELECT_ALL_COMPLETE_RecipeIngredient_BY_Recipe_ID",
                    ( ri, i, r ) =>
                    {
                        i.IdIngredientCategory = ri.IdIngredient;
                        r.IdRecipe = ri.IdRecipe;
                        ri.Recipe = r;
                        ri.Ingredient = i;
                        return ri;
                    }, splitOn: "IngredientIdIngredient,RecipeIdRecipe"
                    , commandType: CommandType.StoredProcedure, param: param ).ToList();
            }
            return recipeIngredient;
        }


        public bool RemoveIngredientsinRecipe( int idRecipe )
        {
            var param = new DynamicParameters();
            param.Add( "@IdRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_DELETE_RecipeIngredient_By_IdRecipe", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }



        public bool RemoveIngredientsinRecipe( int idIngredient, int idRecipe )
        {
            var param = new DynamicParameters();
            param.Add( "@IdRecipe", dbType: DbType.Int32, value: idRecipe, direction: ParameterDirection.Input );
            param.Add( "@IdIngredient", dbType: DbType.Int32, value: idIngredient, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_DELETE_RecipeIngredient", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }



        public bool RemoveRecipesWithIngredient( int idIngredient )
        {
            var param = new DynamicParameters();
            param.Add( "@IdIngredient", dbType: DbType.Int32, value: idIngredient, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_DELETE_RecipeIngredient_By_IdIngredient", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Save( List<RecipeIngredient> recipeIngredients )
        {
            int rvalue = -1;

            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    foreach( RecipeIngredient ingredientCategory in recipeIngredients )
                    {
                        rvalue = connection.Query<int>( "PS_INSERT_RecipeIngredient", new { ingredientCategory.IdIngredient, ingredientCategory.IdRecipe }, commandType: CommandType.StoredProcedure ).FirstOrDefault();

                        if( rvalue == -1 )
                            return false;
                    }
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Remove( int idIngredient, int idRecipe )
        {
            throw new NotImplementedException();
        }
    }
}
