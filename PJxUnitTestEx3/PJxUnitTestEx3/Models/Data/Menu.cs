using System;
using System.Collections.Generic;

namespace UniTestEx.Models.Data
{
    public partial class Menu
    {
        public Menu()
        {
            MenuPermissions = new HashSet<MenuPermission>();
        }

        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public byte? Status { get; set; }

        public virtual ICollection<MenuPermission> MenuPermissions { get; set; }
    }
}
