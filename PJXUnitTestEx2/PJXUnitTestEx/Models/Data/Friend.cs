using System;
using System.Collections.Generic;

namespace PJXUnitTestEx.Models.Data
{
    public partial class Friend
    {
        public int FriendId { get; set; }
        public string? UserId { get; set; }
        public string? FriendUserId { get; set; }
        /// <summary>
        /// 1:好友,2:封鎖,3:刪除
        /// </summary>
        public byte? Status { get; set; }
    }
}
