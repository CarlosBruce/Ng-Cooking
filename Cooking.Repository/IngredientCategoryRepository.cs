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
    public class IngredientCategoryRepository : IIngredientCategoryRepository
    {
        private string _dbConnection;


        private SqlConnection GetConnection()
        {
            //return new SqlConnection( ConfigurationManager.ConnectionStrings["DBConnection"].ToString() );

            return new SqlConnection( this._dbConnection );
        }

        public IngredientCategoryRepository()
        {
            this._dbConnection = "Server=DESKTOP-LI1BB0E;Database=Cooking;Trusted_Connection=True;";
        }

        public List<IngredientCategory> GetAll()
        {
            List<Entities.IngredientCategory> ingredientscat = new List<Entities.IngredientCategory>();

            using( SqlConnection connection = GetConnection() )
            {
                ingredientscat =  connection.Query<Entities.IngredientCategory>( "PS_SELECT_ALL_IngredientCategory", commandType: CommandType.StoredProcedure ).ToList();
            }
            foreach ( Entities.IngredientCategory u in  ingredientscat)
             GetallIngredients( u );

            return ingredientscat;
        }

        private void GetallIngredients( IngredientCategory ingredientCategory )
        {
            Entities.IngredientCategory ingredientcat = new Entities.IngredientCategory();
            var param = new DynamicParameters();
            param.Add( "@IdIngredientCategory", dbType: DbType.Int32, value: ingredientCategory.IdIngredientCategory, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                ingredientCategory.Ingredients.AddRange(connection.Query<Entities.Ingredient>( "PS_SELECT_ALL_Ingredient_BY_CategoryID", commandType: CommandType.StoredProcedure, param: param ).ToList());
            }
        }

        public IngredientCategory GetById( int idIngredientCategory )
        {
            Entities.IngredientCategory ingredientcat = new Entities.IngredientCategory();
            var param = new DynamicParameters();
            param.Add( "@IdIngredientCategory", dbType: DbType.Int32, value: idIngredientCategory, direction: ParameterDirection.Input );
            using( SqlConnection connection = GetConnection() )
            {
                ingredientcat = connection.Query<Entities.IngredientCategory>( "PS_SELECT_ALL_IngredientCategory_BY_ID", commandType: CommandType.StoredProcedure, param: param ).FirstOrDefault();
            }

            GetallIngredients( ingredientcat );
            return ingredientcat;
        }

        public bool Remove( int idIngredientCategory )
        {
            var param = new DynamicParameters();
            param.Add( "@IdIngredientCategory", dbType: DbType.Int32, value: idIngredientCategory, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_Delete_IngredientCategory", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Save( IngredientCategory ingredientCategory )
        {
            int rvalue = -1;

            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    rvalue = connection.Query<int>( "PS_INSERT_IngredientCategory", new { ingredientCategory.Name, ingredientCategory.Description}, commandType: CommandType.StoredProcedure ).FirstOrDefault();
                }
                if( rvalue == -1 )
                    return false;
                else
                    ingredientCategory.IdIngredientCategory = rvalue;
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Update( IngredientCategory ingredientCategory )
        {
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_UPDATE_IngredientCategory", new { ingredientCategory.IdIngredientCategory, ingredientCategory.Name, ingredientCategory.Description }, commandType: CommandType.StoredProcedure );
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
