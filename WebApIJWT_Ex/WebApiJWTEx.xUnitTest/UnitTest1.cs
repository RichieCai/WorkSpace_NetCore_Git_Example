namespace WebApiJWTEx.xUnitTest
{
    public class UnitTest1
    {
        [InlineData("0,0,0", 0)]
        [InlineData("0,1,2", 3)]
        [InlineData("1,2,3", 6)]
        [Fact]
        public void GetWeatherForecast_call()
        {

        }
        [Fact]
        public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        {
        }

    }
}