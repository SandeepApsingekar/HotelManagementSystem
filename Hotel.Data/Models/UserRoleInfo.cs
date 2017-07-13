using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class UserRoleInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserInfoId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual Role Role { get; set; }
    }
}
