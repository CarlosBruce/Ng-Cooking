using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;

namespace Cooking.Repository
{
    public interface IUserRepository
    {
        bool Remove( int idUser );
        bool Save( User user );
        User GetById( int idUser );
        bool Update( User user );
        List<User> GetAll();
    }
}
