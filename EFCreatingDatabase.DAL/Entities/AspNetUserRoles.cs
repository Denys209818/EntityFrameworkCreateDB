using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCreatingDatabase.DAL.Entities
{
    [Table("tblAspNetUserRoles")]
    public class AspNetUserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual AspNetRole Role { get; set; }
    }
}
