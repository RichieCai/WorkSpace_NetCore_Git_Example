namespace WebApiJWTEx.CS
{
    public class csMyLove
    {
        public csMyLove() { 
        }

        public string getShana()
        {
            return "shana";
        }

        public string getChi()
        {
            return "麗秋";
        }

        public string GetMyLoive(string sName)
        {
            Dictionary<string, string> d1 = new Dictionary<string, string>();
            d1.Add("iphone", "優良的");
            d1.Add("google phone", "好用的");
            d1.Add("samsoung", "複雜的");
            var sReuslt = d1.Where(s => s.Key.ToString().ToLower().Trim() == sName.ToString().ToLower().Trim()).ToList()[0].Value;

            return sReuslt;
        }
    }
}
