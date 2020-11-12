using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("loainguoidung", Schema = "banhangnongsan")]
    public partial class Loainguoidung
    {
        public Loainguoidung()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("loainguoidung_ten")]
        [StringLength(40)]
        public string LoainguoidungTen { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty(nameof(User.Loainguoidung))]
        public virtual ICollection<User> Users { get; set; }
    }
}
