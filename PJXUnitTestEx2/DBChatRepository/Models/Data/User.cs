using System;
using System.Collections.Generic;

namespace DBChatRepository.Models.Data
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public DateTime? AddDate { get; set; }
        public byte? Status { get; set; }
        public int? PermissionsId { get; set; }
    }
}
