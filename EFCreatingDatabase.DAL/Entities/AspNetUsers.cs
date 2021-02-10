using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCreatingDatabase.DAL.Entities
{
    [Table("tblAspNetUsers")]
    public class AspNetUser
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string UserName { get; set; }
        [Required, StringLength(255)]
        public string NormalizedUserName { get; set; }
        [Required, StringLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(255), EmailAddress]
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        [Required, StringLength(255)]
        public string PasswordHash { get; set; }
        [Required, StringLength(255)]
        public string SecurityStamp { get; set; }
        [Required, StringLength(255)]
        public string ConcurrencyStamp { get; set; }
        [Required,StringLength(15)]
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        [Required, StringLength(255)]
        public string AccessFailedCount { get; set; }
        public virtual ICollection<AspNetUserRoles> UserRoles { get; set; }

    }
}
