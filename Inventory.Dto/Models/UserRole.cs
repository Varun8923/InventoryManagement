using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.Dto.Models
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        public virtual User User { get; set; }
    }
}
