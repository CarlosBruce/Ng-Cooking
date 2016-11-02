using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cooking.Entities;
using FizzWare.NBuilder;
using System.Collections.Generic;

namespace CookingRepositoryTest
{
    [TestClass]
    public class UserRepositoryTest
    {

        public IList<User>  userListForTest;
        Cooking.Repository.IUserRepository userRepository;

        [TestInitialize()]
        public void Initialize()
        {
            userRepository = new Cooking.Repository.UserRepository();
            userListForTest =   Builder<User>.CreateListOfSize(20)
                                .All()
                                .With(x => x.IdUser = -1)
                                .Build();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            foreach ( User u in userListForTest )
                userRepository.Remove( u.IdUser );
        }


        [TestMethod]
        public void Check_Add_NewUser()
        {
           bool result = userRepository.Save( userListForTest[0] );

            Assert.AreEqual( result, true );
            Assert.AreNotEqual( userListForTest[0].IdUser, -1 );
        }


        [TestMethod]
        public void Check_Get_User()
        {
            bool result = userRepository.Save( userListForTest[0] );

            Assert.AreEqual( result, true );

            User userResult = userRepository.GetById( userListForTest[0].IdUser );

            Assert.AreEqual( userListForTest[0].IdUser, userResult.IdUser);
        }

        [TestMethod]
        public void Check_Update_User()
        {
            bool result = userRepository.Save( userListForTest[0] );

            Assert.AreEqual( result, true );

            string old_value = userListForTest[0].Login;
            userListForTest[0].Login = "ModificationUserLogi";

            result = userRepository.Update( userListForTest[0]);
            Assert.AreEqual( result, true );

            User userResult = userRepository.GetById( userListForTest[0].IdUser );
            Assert.AreEqual( userResult.Login, userListForTest[0].Login );
        }

        [TestMethod]
        public void Check_Delete_User()
        {
            bool result = userRepository.Save( userListForTest[0] );
            Assert.AreEqual( result, true );

            User userResult = userRepository.GetById( userListForTest[0].IdUser );
            Assert.AreEqual( userResult.IdUser, userResult.IdUser );

            bool deletionResult = userRepository.Remove( userListForTest[0].IdUser );
            Assert.AreEqual( deletionResult, true );

            userResult =  userRepository.GetById( userListForTest[0].IdUser );
            Assert.AreEqual( userResult, null);
        }


        [TestMethod]
        public void Check_Get_ListAllUser()
        {
            foreach( User u in userListForTest )
                userRepository.Save(u) ;

            List<User> result = userRepository.GetAll();

            Assert.AreEqual( result.Count, 20 );
        }
    }
}
