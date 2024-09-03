namespace WebApiJWTEx.CS
{
    public class csPriceCalculator
    {
        public  csPriceCalculator() { }
        public int GetDiscountedPrice(int price, IDateTimeProvider dateTimeProvider)
        {
            if (dateTimeProvider.DayOfWeek() == DayOfWeek.Tuesday)
            {
                return price / 2;
            }
            else
            {
                return price;
            }
        }

        public interface IDateTimeProvider
        {
            DayOfWeek DayOfWeek();
        }


    }
}
