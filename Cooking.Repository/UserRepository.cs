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
    public class UserRepository : IUserRepository
    {
        private string _dbConnection;

        private SqlConnection GetConnection()
        {
            //return new SqlConnection( ConfigurationManager.ConnectionStrings["DBConnection"].ToString() );

            return new SqlConnection(this._dbConnection);
        }

        public UserRepository()
        {
            this._dbConnection = "Server=DESKTOP-LI1BB0E;Database=Cooking;Trusted_Connection=True;";
        }

        public List<User> GetAll()
        {
            List<Entities.User> users = new List<Entities.User>();

            using( SqlConnection connection = GetConnection() )
            {
                users = connection.Query<Entities.User>( "PS_SELECT_ALL_User", commandType: CommandType.StoredProcedure ).ToList();
            }
            foreach( User u in users )
            {
                u.Recipes = getUserRecipes( u.IdUser );
                u.RecipeRates = getUserRecipeRates( u.IdUser );
            }

            return users;
        }

        private List<Recipe> getUserRecipes(int idUser )
        {
            List<Entities.Recipe> recipes = new List<Entities.Recipe>();
            var param = new DynamicParameters();
            param.Add( "@IdUser", dbType: DbType.Int32, value: idUser, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipes = connection.Query<Entities.Recipe>( "PS_SELECT_ALL_Recipe_BY_User_ID", commandType: CommandType.StoredProcedure, param: param ).ToList();
            }

            return recipes;
        }



        public User GetById( int idUser )
        {
            Entities.User user = new Entities.User();
            var param = new DynamicParameters();
            param.Add( "@IdUser", dbType: DbType.Int32, value: idUser, direction: ParameterDirection.Input );
            using( SqlConnection connection = GetConnection() )
            {
                user = connection.Query<Entities.User>( "PS_SELECT_ALL_User_BY_ID", commandType: CommandType.StoredProcedure, param: param ).FirstOrDefault();
            }
            user.Recipes = getUserRecipes( idUser );
            user.RecipeRates = getUserRecipeRates( user.IdUser );
            return user;
        }

        private List<RecipeRate> getUserRecipeRates( int idUser )
        {
            List<Entities.RecipeRate> recipesRates = new List<Entities.RecipeRate>();
            var param = new DynamicParameters();
            param.Add( "@IdUser", dbType: DbType.Int32, value: idUser, direction: ParameterDirection.Input );

            using( SqlConnection connection = GetConnection() )
            {
                recipesRates = connection.Query<Entities.RecipeRate>( "PS_SELECT_ALL_RecipeRate_BY_User_ID", commandType: CommandType.StoredProcedure, param: param ).ToList();
            }

            return recipesRates;
        }

        public bool Remove( int idUser )
        {
            var param = new DynamicParameters();
            param.Add( "@IdUser", dbType: DbType.Int32, value: idUser, direction: ParameterDirection.Input );
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_Delete_User", commandType: CommandType.StoredProcedure, param: param );
                }
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Save( User user )
        {
            int rvalue = -1;

            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    rvalue = connection.Query<int>( "PS_INSERT_User", new { user.Email,  user.Login, user.Password, user.UrlProfilPicture }, commandType: CommandType.StoredProcedure ).FirstOrDefault();
                }
                if( rvalue == -1 )
                    return false;
                else
                    user.IdUser = rvalue;
            }
            catch( SqlException e )
            {
                throw e;
            }
            return true;
        }

        public bool Update( User user )
        {
            try
            {
                using( SqlConnection connection = GetConnection() )
                {
                    connection.Execute( "PS_UPDATE_User", new { user.IdUser, user.Email, user.Login, user.Password, user.UrlProfilPicture }, commandType: CommandType.StoredProcedure );
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
