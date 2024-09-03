using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PJXUnitTestEx.Controllers;
using PJXUnitTestEx.Interface;
using PJXUnitTestEx.Models.Data;
using PJXUnitTestEx_xUnitTest.MockData;


namespace PJXUnitTestEx_xUnitTest.Controllers
{
    public class UserControllerTest
    {


        [Fact]
        public async Task GetUserAsync()
        {
        }

        [Fact]
        public async Task GetUserAllAsync_ShouldReturn200Status()
        {
            //Arrange
            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetUserAllAsync()).ReturnsAsync(UserMockData.GetUserAll());
            var sut = new UserController(userService.Object);

            //Acat
            var result =  await sut.GetUserAllAsync();

            //Assert
            //法1
            result.GetType().Should().Be(typeof(OkObjectResult));//檢查是否為該型態
             (result as OkObjectResult).StatusCode.Should().Be(200);//檢查是否為200

        }


        [Fact]
        public async Task GetUserAllAsync_ShouldReturn204Status()
        {
            //Arrange
            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetUserAllAsync()).ReturnsAsync(UserMockData.EmptyUserAll());
            var sut = new UserController(userService.Object);

            //Acat
            var result = await sut.GetUserAllAsync();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));//檢查是否為該型態
            (result as NoContentResult).StatusCode.Should().Be(204);//檢查是否為200

        }


        //[Theory]
        //[InlineData("Richie")]
        //public async Task GetUserAsync(string UserName)
        //{
        //    //Arrange
        //    var userService = new Mock<IUserService>();
        //    userService.Setup(x => x.GetUserAsync(UserName)).ReturnsAsync(UserMockData.GetUser(UserName));
        //    var sut = new UserController(userService.Object);

        //    //Acat
        //    var result = await sut.GetUserAsync(UserName);

        //    //Assert
        //    result.GetType().Should().Be(typeof(NoContentResult));//檢查是否為該型態
        //    (result as NoContentResult).StatusCode.Should().Be(204);//檢查是否為200
        //}



        [Fact]
        public async Task SaveAsync_ShouldCallUserAsyncOnce()
        {
            //Arrange
            var userService = new Mock<IUserService>();
            var newUser = UserMockData.AddUser();

            var sut = new UserController(userService.Object);

            //Act
            var result = await sut.SaveAsync(newUser);

            //Assert
            userService.Verify(x => x.SaveAsync(newUser), Times.Exactly(1));
        }
    }
}
