using DataTier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using WebServices.Controllers;

namespace Test
{
    [TestClass]
    public class UserTest
    {
        private readonly IUserRepository _repository;
        private readonly UserController _controller;

        public UserTest()
        {
            _repository = new MockUserRepository();
            _controller = new UserController(_repository);
        }

        [TestMethod]
        public void GetReturnsAllUsers()
        {
            //act
            var users = _controller.Get();

            //assert
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void GetReturnsUserWithSameId()
        {
            //act
            var user = _controller.Get(1);

            //assert
            Assert.IsNotNull(user);
            Assert.AreEqual(GetUser().Id, user.Id);
        }

        private User GetUser()
        {
            var user = new User { Id = 1, FirstName = "Bruce", LastName = "Banner" };
            return user;
        }
    }
}
