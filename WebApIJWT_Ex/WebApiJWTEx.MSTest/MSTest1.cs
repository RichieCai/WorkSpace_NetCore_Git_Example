using Moq;
using WebApiJWTEx.CS;
using static WebApiJWTEx.CS.csPriceCalculator;

namespace WebApiJWTEx.MSTest
{
    [TestClass]
    public class MSTest1
    {
        [TestMethod]
        public void GetWeatherForecast_call()
        {

        }

        [TestMethod]
        public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        {
            //排列(Arrange)
            var priceCalculator = new csPriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            //作用(Act)
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Monday);
            
            //判斷提示(Assert)
            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);
            Assert.AreEqual(2, actual);
        }
        [TestMethod]
        public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
        {
            var priceCalculator = new csPriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Tuesday);
            
            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);

            Assert.AreEqual(1, actual);
        }

    }
}