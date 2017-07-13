using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserInfo> Users { get; set; }
    }
}