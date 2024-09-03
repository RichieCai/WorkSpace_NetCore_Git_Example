using Generally.data;
using Generally.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApiJWTEx.Controllers;
using WebApiJWTEx.CS;

using static WebApiJWTEx.CS.csPriceCalculator;

namespace WebApiJWTEx.MSTest
{
    [TestClass]
    public class TodoListTest
    {
        [TestInitialize]
        public void Init() 
        { 
        
        }
        /* 測試如何 使用mock(模仿)假物件,來模擬取資料的過程 */
 
        [TestMethod]
        public void GetIDTest_Get_OneData()
        {
            var mock=new Mock<IToDoListRepository>();//先模擬出一個 MemberRepository 物件，此時的 mock 物件型別為 Moq.Mock<WebApiJWTEx.CS.IToDoListRepository>
            mock.Setup(p => p.Get(13)).Verifiable();//一定要被執行過才算數 ( Verifiable )
            //mock.Setup(p => p.Get(13)).ReturnsAsync(to)

            TodoListController tdlc = new TodoListController(mock.Object);
            //設定完成後取出被 Mock 過的物件，並傳入 TodoListController 控制器。
            //註: 此時 mock.Object 物件就是 IToDoListRepository 型別，可以傳入 TodoListController 控制器。

            var result = tdlc.GetIDTest(13);

            Assert.IsInstanceOfType(result, typeof(Task<ActionResult<ToDoList>>));

        }

      

    }
}