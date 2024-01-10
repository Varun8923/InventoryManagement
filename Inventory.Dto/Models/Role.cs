using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.Dto.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? AddedBy { get; set; }
        public bool? RoleIsActive { get; set; }
    }
}
