using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("tinhtranghd", Schema = "banhangnongsan")]
    public partial class Tinhtranghd
    {
        public Tinhtranghd()
        {
            Donhangs = new HashSet<Donhang>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("tinhtranghd_ten")]
        [StringLength(100)]
        public string TinhtranghdTen { get; set; }
        [Column("tinhtranghd_mo_ta")]
        public string TinhtranghdMoTa { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty(nameof(Donhang.Tinhtranghd))]
        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}
