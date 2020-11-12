using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("nhom", Schema = "banhangnongsan")]
    public partial class Nhom
    {
        public Nhom()
        {
            Loaisanphams = new HashSet<Loaisanpham>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nhom_ten")]
        [StringLength(50)]
        public string NhomTen { get; set; }
        [Required]
        [Column("nhom_url")]
        [StringLength(100)]
        public string NhomUrl { get; set; }
        [Column("nhom_mo_ta")]
        public string NhomMoTa { get; set; }
        [Required]
        [Column("nhom_anh")]
        [StringLength(255)]
        public string NhomAnh { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty(nameof(Loaisanpham.Nhom))]
        public virtual ICollection<Loaisanpham> Loaisanphams { get; set; }
    }
}
