using Moq;
using WebApiJWTEx.CS;
using static WebApiJWTEx.CS.csPriceCalculator;

namespace WebApiJWTEx.NUnitTest
{
    public class Tests
    {
        csPriceCalculator priceCalculator1 = null;
        //該方法同於建構函數
        [SetUp]
        public void Setup()
        {
            //沒有作用
            priceCalculator1 = new csPriceCalculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        /*
         GetDiscountedPrice_NotTuesday_ReturnsFullPrice,如果是不是星期2則返回2
        GetDiscountedPrice_OnTuesday_ReturnsHalfPrice 如果是星期2則反回1
        這兩個方法示範了如何使用mock(模仿)
        mock為一個假物件，只要裡面給interface類別，則可以做到假動作，
         */
        [Test]
        public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        {
            var priceCalculator = new csPriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Monday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);

            Assert.AreEqual(2, actual);
        }
        [Test]
        public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
        {
            var priceCalculator = new csPriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Tuesday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);

            Assert.AreEqual(1, actual);
        }
        /* 測試如何傳入資料 */
        [TestCase("iphone", "優良的")]
        [TestCase("google phone", "好用的")]
        [TestCase("samsoung", "複雜的")]
        public void GetMyLoive(string sName, string sTaget)
        {
            var vMyLove = new csMyLove();

            var actual = vMyLove.GetMyLoive(sName);

            Assert.AreEqual(sTaget, actual);
        }

        [Test]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            csTest test = new csTest();
            var result = test.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            csTest test = new csTest();
            var result = test.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
    }
}