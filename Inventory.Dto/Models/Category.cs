using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.Dto.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDecription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreadtedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
