using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("chitietdonhang", Schema = "banhangnongsan")]
    [Index(nameof(DonhangId), Name = "chitietdonhang_donhang_id_foreign")]
    [Index(nameof(SanphamId), Name = "chitietdonhang_sanpham_id_foreign")]
    public partial class Chitietdonhang
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("sanpham_id")]
        public long SanphamId { get; set; }
        [Column("donhang_id")]
        public long DonhangId { get; set; }
        [Column("chitietdonhang_so_luong")]
        public int ChitietdonhangSoLuong { get; set; }
        [Column("chitietdonhang_thanh_tien", TypeName = "decimal(10, 2)")]
        public decimal ChitietdonhangThanhTien { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(DonhangId))]
        [InverseProperty("Chitietdonhangs")]
        public virtual Donhang Donhang { get; set; }
        [ForeignKey(nameof(SanphamId))]
        [InverseProperty("Chitietdonhangs")]
        public virtual Sanpham Sanpham { get; set; }
    }
}
