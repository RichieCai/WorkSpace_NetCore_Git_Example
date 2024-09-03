using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using PJXUnitTestEx.Context;
using PJXUnitTestEx.Interface;
using PJXUnitTestEx.Service;
using PJXUnitTestEx_xUnitTest.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJXUnitTestEx_xUnitTest.Service
{
    public class UserServiceTest:IDisposable
    {
        private readonly dbChatMSContext _dbContext;
        public UserServiceTest()
        {
            var optiopn = new DbContextOptionsBuilder<dbChatMSContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _dbContext = new dbChatMSContext(optiopn);

            _dbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAllAsync_ReturnUserCollection()
        {

            //Arrange
            _dbContext.Users.AddRange(UserMockData.GetUserAll());
            _dbContext.SaveChanges();

            var sut = new UserService(_dbContext);

            //Assert
            var result = await sut.GetUserAllAsync();

            //Assert
            result.Should().HaveCount(UserMockData.GetUserAll().Count);
        }

        [Fact]
        public async Task SaveAsync_AddNewUser()
        {
            //Arrange
            _dbContext.Users.AddRange(UserMockData.GetUserAll());
            _dbContext.SaveChanges();

            var newUser = UserMockData.AddUser();
            var sut = new UserService(_dbContext);

            //Assert
            await sut.SaveAsync(newUser);

            //Assert
            int exptedRecordCount = UserMockData.GetUserAll().Count + 1;

            _dbContext.Users.Count().Should().Be(exptedRecordCount);

        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
