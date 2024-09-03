namespace WebApIJWT_Ex.other
{
    public class Const
    {
        /// <summary>
        /// 這裡為了演示，寫死一個金鑰。實際生產環境可以從配置檔案讀取,這個是用網上工具隨便生成的一個金鑰（md5或者其他都可以）
        /// </summary>
        public const string SecurityKey = "48754F4C58F9EA428FE09D714E468211";

        /// <summary>
        /// 站點地址（頒發者、接受者），這裡測試和當前本地執行網站相同，實際發到正式環境應為域名地址
        /// </summary>
        public const string Domain = "https://localhost:44345";

        /// <summary>
        /// 受理人，之所以弄成可變的是為了用介面動態更改這個值以模擬強制Token失效
        /// 真實業務場景可以在資料庫或者redis存一個和使用者id相關的值，生成token和驗證token的時候獲取到持久化的值去校驗
        /// 如果重新登陸，則重新整理這個值
        /// </summary>
        public static string ValidAudience;
    }
}
