using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCreatingDatabase.DAL.Entities
{
    [Table("tblAspNetRoles")]
    public class AspNetRole
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string NormalizedName { get; set; }
        [Required, StringLength(255)]
        public string ConcurrencyStamp { get; set; }
        public virtual ICollection<AspNetUserRoles> UserRoles { get; set; }

    }
}
