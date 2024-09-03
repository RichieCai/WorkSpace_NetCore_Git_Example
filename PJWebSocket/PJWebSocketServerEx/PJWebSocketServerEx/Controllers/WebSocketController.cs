using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace PJWebSocketServerEx.Controllers
{
    public class WebSocketController : Controller
    {
        [HttpGet("/ws")]
        public async Task Get()
        {
            //是否為webSocket請求 如果是則加入等待
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private static async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            //等待接收訊息
            var receiveResult = await webSocket.ReceiveAsync(
                 new ArraySegment<byte>(buffer), CancellationToken.None);
            //檢查是否為連線狀態
            while (!receiveResult.CloseStatus.HasValue)
            {
                //訊息發到前端
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None
                    );
                //繼續等待接收訊息
                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);

            }
            //關閉連線
            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription, CancellationToken.None);

        }
    }
}
