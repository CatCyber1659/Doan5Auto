using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("loaisanpham", Schema = "banhangnongsan")]
    [Index(nameof(NhomId), Name = "loaisanpham_nhom_id_foreign")]
    public partial class Loaisanpham
    {
        public Loaisanpham()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("loaisanpham_ten")]
        [StringLength(200)]
        public string LoaisanphamTen { get; set; }
        [Column("loaisanpham_mo_ta")]
        public string LoaisanphamMoTa { get; set; }
        [Required]
        [Column("nhom_id")]
        public long NhomId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set;}

        [ForeignKey(nameof(NhomId))]
        [InverseProperty("Loaisanphams")]
        public virtual Nhom Nhom { get; set; }
        [InverseProperty(nameof(Sanpham.Loaisanpham))]
        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
