using WebChatSingleR_Ex.Meta;

namespace WebChatSingleR_Ex.Serivce
{
    public class Account
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Passowrd { get; set; }
        public Account()
        {

        }

        public bool IsCheckAccount(string sUserId, string sPassword)
        {
            List<Account> listResult = MetaData.SetData();
            var vData = listResult.Where(x => x.UserId == sUserId && x.Passowrd == sPassword).FirstOrDefault();

            bool bResult = (vData != null) ? true : false;
            return bResult;

        }

        public bool GetAccount(string sUserId)
        {
            List<Account> listResult = MetaData.SetData();
            var vData = listResult.Where(x => x.UserId == sUserId).FirstOrDefault();
            return vData != null;
        }
    }
}
