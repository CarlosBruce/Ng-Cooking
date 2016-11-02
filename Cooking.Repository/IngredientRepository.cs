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
    public class IngredientRepository : IIngredientRepository
    {
        private string _dbConnection;

        private SqlConnection GetConnection()
        {
            //return new SqlConnection( ConfigurationManager.ConnectionStrings["DBConnection"].ToString() );

            return new SqlConnection( this._dbConnection );
        }

        public IngredientRepository()
        {
            this._dbConnection = "Server=DESKTOP-LI1BB0E;Database=Cooking;Trusted_Connection=True;";
        }

        public List<Ingredient> GetAll()
        {
            List<Entities.Ingredient> ingredients = new List<Entities.Ingredient>();

            using( SqlConnection connection = GetConnection() )
            {
                ingredients = connection.Query<Entities.Ingredient, Entities.IngredientCategory, Entities.Ingredient>( "PS_SELECT_ALL_COMPLETE_Ingredient",
                    ( i, ic ) =>
                    {
                        ic.IdIngredientCategory = i.IdIngredientCategory;
                        i.IngredientCategory = ic;
                        return i;
                    }, splitOn: "IngredientCategoryIdIngredientCategory"
                    ,commandType: CommandType.StoredProcedure ).ToList();
            }

            return ingredients;
        }

        public Ingredient GetById( int idIngredient )
        {
            Entities.Ingredient ingredient = new Entities.Ingredient();
            var param = new DynamicParameters();
            param.Add( "@IdIngredient", dbType: DbType.Int32, value: idIngredient, direction: ParameterDirection.Input );
            using( SqlConnection connection = GetConnection() )
            {
                ingredient = connection.Query<Entities.Ingredient, Entities.IngredientCategory, Entities.Ingredient>
                    ( "PS_SELECT_ALL_COMPLETE_Ingredient_BY_ID",
                    (i, ic) => 
                    {
                        ic.IdIngredientCategory = i.IdIngredientCategory;
                        i.IngredientCategory = ic;
                        return i;
                    },splitOn: "IngredientCategoryIdIngredientCategory"
                    , commandType: CommandType.StoredProcedure, param: param ).FirstOrDefault();
            }
            return ingredient;
        }

        public bool Remove( int idIngredient )
        {
            var param = new DynamicParameters();
            param.Add( "@IdIngredient", dbType: DbType.Int32, value: idIngredient, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_Delete_Ingredient", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Save( Ingredient ingredient )
        {
            int rvalue = -1;

            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    rvalue = connection.Query<int>( "PS_INSERT_Ingredient", new { ingredient.Calories, ingredient.IdIngredientCategory, ingredient.Name,ingredient.UrlIngredientPicture }, commandType: CommandType.StoredProcedure ).FirstOrDefault();
                }
                if( rvalue == -1 )
                    return false;
                else
                    ingredient.IdIngredient = rvalue;
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Update( Ingredient ingredient )
        {
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_UPDATE_Ingredient", new { ingredient.IdIngredient, ingredient.Calories, ingredient.IdIngredientCategory, ingredient.Name }, commandType: CommandType.StoredProcedure );
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
