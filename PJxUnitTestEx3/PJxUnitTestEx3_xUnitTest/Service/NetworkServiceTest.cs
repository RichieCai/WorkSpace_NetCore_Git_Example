using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UniTestEx.Interface;
using UniTestEx.Repository;
using UniTestEx.Service;

namespace UniTestEx_xUnitTest.Service
{
    /// <summary>
    /// 使用 FakeItEasy
    /// </summary>
    public class NetworkServiceTest
    {

        private readonly NetworkService _pingService = null;
        private readonly IUserRepository _userRepository;

        public NetworkServiceTest()
        {
            //Depdencies
            _userRepository = A.Fake<IUserRepository>();
            //Arrange -variables,classes,mocks
            _pingService = new NetworkService(_userRepository);
        }

        /// <summary>
        /// 字串檢查
        /// </summary>
        [Fact]
        public void SendPing_ReturnString()
        {
            //Arrange -variables,classes,mocks
            A.CallTo(() => _userRepository.IsUser()).Returns(true);


            //Act
            var vResult = _pingService.SendPing();

            //Assert
            vResult.Should().NotBeNullOrWhiteSpace();
            vResult.Should().Be("成功結果!");
            vResult.Should().Contain("成功", Exactly.Once());

        }

        /// <summary>
        /// 運算檢查
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(15, 20, 35)]
        [InlineData(22, 55, 77)]
        public void PingTimeout_ReturnSum(int a, int b, int expected)
        {
            //Act
            var vResult = _pingService.PingTimeout(a, b);

            //Assert
            vResult.Should().Be(expected);
            vResult.Should().BeGreaterThanOrEqualTo(0);//大於或等於
            vResult.Should().NotBeInRange(-100000, 0);//不等於該範圍
        }

        /// <summary>
        /// 日期檢查
        /// </summary>
        [Fact]
        public void LastPingDate_ReturnNowDate()
        {
            //Arragne

            //Act
            var vResult = _pingService.LastPingDate();

            //Assert
            vResult.Should().BeAfter(1.January(2010));
            vResult.Should().BeBefore(1.January(2050));

        }


        /// <summary>
        /// 物件檢查
        /// </summary>
        [Fact]
        public void GetPingOptions_ReturnObj()
        {
            //Arrange
            var expected = new PingOptions()
            {
                    DontFragment=true,
                    Ttl=1
            };
            //Act
            var vResult = _pingService.GetPingOptions();

            //Assert 
            vResult.Should().BeOfType<PingOptions>();//檢查類型
            vResult.Should().BeEquivalentTo(expected);
            vResult.Ttl.Should().Be(1);
        }

        /// <summary>
        /// IEnumerble 檢查
        /// </summary>
        [Fact]
        public void MostRecentPings_ReturnIEnumerble()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //Act
            var vResult = _pingService.MostRecentPings();

            //Assert 
           // vResult.Should().BeOfType<IEnumerable<PingOptions>>();//檢查類型
            vResult.Should().ContainEquivalentOf(expected);
            vResult.Should().Contain(x => x.DontFragment == true);


        }
    }
}
