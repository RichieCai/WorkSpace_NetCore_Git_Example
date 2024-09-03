using System;
using System.Collections.Generic;

namespace DBChatRepository.Models.Data
{
    public partial class Room
    {
        public int? RoomId { get; set; }
        public string? UserId { get; set; }
        public string? ToUser { get; set; }
        public byte? Type { get; set; }
    }
}
