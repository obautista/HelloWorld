using Model;
using Xunit;
using System;
using DataTier;
using System.Linq;
using WebServices.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UnitTest
{
    public class UserControllerTest
    {
        private readonly IUserRepository _repository;
        private readonly UserController _controller;

        public UserControllerTest()
        {
            _repository = new MockUserRepository();
            _controller = new UserController(_repository);
        }

        [Fact]
        public void Test_Get_Returns_OkObjectResult_Type()
        {
            //act
            var okResult = _controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Test_Get_Returns_A_List_Of_Type_User()
        {
            //act
            var okResult = _controller.Get().Result as OkObjectResult;

            //assert
            Assert.IsType<List<User>>(okResult.Value);
        }

        [Fact]
        public void Test_Get_Does_Not_Return_Null()
        {
            //act
            var users = _controller.Get();

            //assert
            Assert.NotNull(users);
        }

        [Fact]
        public void Test_Get_Returns_All_Items()
        {
            //act
            var okResult = _controller.Get().Result as OkObjectResult;

            //assert
            Assert.Equal(3, (okResult.Value as List<User>).Count);
        }

        [Fact]
        public void Test_Get_Returns_User_With_SameId()
        {
            //act
            var okResult = _controller.Get(1).Result as OkObjectResult;

            //assert
            Assert.Equal(GetUser().Id, (okResult.Value as User).Id);
        }

        [Fact]
        public void Test_Get_Using_Int_That_Does_Not_Exist_Returns_NotFoundResult()
        {
            //act
            var notFoundResult = _controller.Get(new Random().Next(100, int.MaxValue));

            //assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Test_Add_Invalid_Object_Passed_Returns_BadRequest()
        {
            //arrange
            var badUser = new User()
            {
                FirstName = "John"
            };

            _controller.ModelState.AddModelError("LastName", "Required");

            //act
            var badResponse = _controller.Post(badUser);

            //assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Test_Add_ValidObject_Returns_CreatedResponse()
        {
            //arrange
            var newUser = new User()
            {
                FirstName = "Ringo",
                LastName = "Starr"
            };

            //act
            var createdResponse = _controller.Post(newUser);

            //assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Test_Add_ValidObject_Returns_Response_Has_Created_Item()
        {
            //arrange
            var newUser = new User()
            {
                FirstName = "Paul",
                LastName = "Mccartney"
            };

            //act
            var createdResponse = _controller.Post(newUser) as CreatedAtActionResult;
            var createdUser = createdResponse.Value as User;

            //assert
            Assert.IsType<User>(createdUser);
            Assert.Equal("Mccartney", createdUser.LastName);
        }

        [Fact]
        public void Test_Remove_NonExistingId_Returns_NotFoundResponse()
        {
            //arrange
            var badId = new Random().Next(100, int.MaxValue);

            //act
            var badResponse = _controller.Remove(badId);

            //assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Test_Remove_ExistingId_Returns_OkResult()
        {
            //arrange
            var existingId = 1;

            //act
            var okResponse = _controller.Remove(existingId);

            //assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Test_Remove_ExistingId_Removes_OneItem()
        {
            //arrange
            var existingId = 1;

            //act
            var okResponse = _controller.Remove(existingId);

            //assert
            Assert.Equal(2, _repository.GetAllUsers().Count());
        }

        private User GetUser()
        {
            var user = new User { Id = 1, FirstName = "Bruce", LastName = "Banner" };
            return user;
        }
    }
}
