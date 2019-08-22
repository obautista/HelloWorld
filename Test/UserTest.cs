using DataTier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using WebServices.Controllers;

namespace Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetReturnsAllUsers()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            var userController = new UserController(mockUserRepository.Object);

            // Act
            var users = userController.Get();

            // Assert
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void GetReturnsUserWithSameId()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetUser(1)).Returns(new User { Id = 1 });
            var userController = new UserController(mockUserRepository.Object);

            // Act
            var user = userController.Get(1);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
        }
    }
}
