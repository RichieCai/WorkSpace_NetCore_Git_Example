using Moq;
using WebApiJWTEx.CS;
using static WebApiJWTEx.CS.csPriceCalculator;

namespace WebApiJWTEx.NUnitTest
{
    public class Tests
    {
        csPriceCalculator priceCalculator1 = null;
        //�Ӥ�k�P��غc���
        [SetUp]
        public void Setup()
        {
            //�S���@��
            priceCalculator1 = new csPriceCalculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        /*
         GetDiscountedPrice_NotTuesday_ReturnsFullPrice,�p�G�O���O�P��2�h��^2
        GetDiscountedPrice_OnTuesday_ReturnsHalfPrice �p�G�O�P��2�h�Ϧ^1
        �o��Ӥ�k�ܽd�F�p��ϥ�mock(�ҥ�)
        mock���@�Ӱ�����A�u�n�̭���interface���O�A�h�i�H���찲�ʧ@�A
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
        /* ���զp��ǤJ��� */
        [TestCase("iphone", "�u�}��")]
        [TestCase("google phone", "�n�Ϊ�")]
        [TestCase("samsoung", "������")]
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