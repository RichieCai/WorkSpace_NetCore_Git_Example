using System;
using System.Collections.Generic;

namespace UniTestEx.Models.Data
{
    public partial class MenuPermission
    {
        public int MenuPermissionsId { get; set; }
        public string? MenuPermissionsName { get; set; }
        public int? MenuId { get; set; }
        public int? PermissionsId { get; set; }

        public virtual Menu? Menu { get; set; }
        public virtual Permission? Permissions { get; set; }
    }
}
