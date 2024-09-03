using WebChatSingleR_Ex.Serivce;

namespace WebChatSingleR_Ex.Meta
{
    public class MetaData
    {
        public MetaData()
        {


        }
        public static List<Account>  SetData()
        {
            List<Account> listAcat = new List<Account>() {
            new(){
                UserId = "a111",
                UserName = "曉風",
                Passowrd="a1234"
            },
                        new(){
                UserId = "a222",
                UserName = "阿喜",
                Passowrd="a1234"
            },
                                    new(){
                UserId = "a333",
                UserName = "路克",
                Passowrd="a1234"
            },
            };

            return listAcat;

        }
    }
}
