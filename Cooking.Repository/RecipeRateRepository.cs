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
    public class RecipeRateRepository : IRecipeRateRepository
    {
        private string _dbConnection;

        private SqlConnection GetConnection()
        {
            //return new SqlConnection( ConfigurationManager.ConnectionStrings["DBConnection"].ToString() );

            return new SqlConnection( this._dbConnection );
        }

        public RecipeRateRepository()
        {
            this._dbConnection = "Server=DESKTOP-LI1BB0E;Database=Cooking;Trusted_Connection=True;";

        }


        public bool Save( RecipeRate recipeRate )
        {
            int rvalue = -1;

            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                     connection.Execute( "PS_INSERT_RecipeRate", new { recipeRate.IdUser, recipeRate.Rate, recipeRate.Title,recipeRate.IdRecipe, recipeRate.Comment }, commandType: CommandType.StoredProcedure );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

    }
}
