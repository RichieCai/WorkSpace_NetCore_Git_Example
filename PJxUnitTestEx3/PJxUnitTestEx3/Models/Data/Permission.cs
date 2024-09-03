using System;
using System.Collections.Generic;

namespace UniTestEx.Models.Data
{
    public partial class Permission
    {
        public Permission()
        {
            MenuPermissions = new HashSet<MenuPermission>();
        }

        public int PermissionsId { get; set; }
        public string? PermissionsName { get; set; }
        public byte? Status { get; set; }

        public virtual ICollection<MenuPermission> MenuPermissions { get; set; }
    }
}
