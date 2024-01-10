using System;
using System.Collections.Generic;

#nullable disable

namespace Inventory.Dto.Models
{
    public partial class User
    {
        public User()
        {
            People = new HashSet<Person>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int? RoleId { get; set; }
        public int? PersonId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public string Ip { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
