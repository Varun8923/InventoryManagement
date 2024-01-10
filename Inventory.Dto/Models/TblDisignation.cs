using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.Dto.Models
{
    public partial class TblDisignation
    {
        public int DisignationId { get; set; }
        public string DisignationName { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public string CreateIpAddress { get; set; }
    }
}
