using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace WebChatSingleR_Ex.Hubs
{
    public class ChatHub : Hub
    {

        public static List<string> ConnIDList = new List<string>();
        string[] UserList = new string[] {"a001","b001","c001" };

        /// <summary>
        /// 連顯事件
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            if (ConnIDList.Where(p => p == Context.ConnectionId).FirstOrDefault() == null)
            {
                ConnIDList.Add(Context.ConnectionId);
            }
            //更新連線ID列表
            string jsonString = JsonConvert.SerializeObject(ConnIDList);
            await Clients.All.SendAsync("UpdateList", jsonString);

            //更新個人ID
            await Clients.Client(Context.ConnectionId).SendAsync("UpdateSelfID", Context.ConnectionId);

            //更新聊天內容
            await Clients.All.SendAsync("UadateContent", "新連線 ID:" + Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            string? id = ConnIDList.Where(p => p == Context.ConnectionId).FirstOrDefault();
            if (id != null)
            {
                ConnIDList.Remove(id);
            }
            string jsonString= JsonConvert.SerializeObject(ConnIDList);
            await Clients.All.SendAsync("UpdateList", jsonString);

            await Clients.All.SendAsync("UadateContent", "已離線ID:" + Context.ConnectionId);

            await base.OnDisconnectedAsync(ex);
        }



        public async Task SendMessage(string UserId, string sendToID, string message)
        {
            if (string.IsNullOrEmpty(sendToID))
            {
                await Clients.All.SendAsync("UadateContent", UserId + "說:"+ message);
            }
            else
            {
                await Clients.Client(sendToID).SendAsync("UadateContent", $"{UserId}+私訊向你說:{message}");
                await Clients.Client(Context.ConnectionId).SendAsync("UadateContent", $"你說向{sendToID}發起私訊:{message}");
            }
        }
    }
}
