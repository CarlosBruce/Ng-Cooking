using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cooking.Entities;
using Cooking.Repository;

namespace Cooking.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo )
        {
            _userRepo = userRepo;
        }

        public bool Add( User u )
        {
           return _userRepo.Save( u );
        }

        public List<User> Get()
        {
            return _userRepo.GetAll();
        }

        public User Get( int id )
        {
            User u = _userRepo.GetById( id );

            return u;
        }

        public User LogUser( User u )
        {
            return _userRepo.LogByLoginAndPassword( u.Login, u.Password);
        }

        public bool Remove( int id )
        {
            return _userRepo.Remove( id );
        }
    }
}
