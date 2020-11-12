using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("donhang", Schema = "banhangnongsan")]
    [Index(nameof(KhachhangId), Name = "donhang_khachhang_id_foreign")]
    [Index(nameof(TinhtranghdId), Name = "donhang_tinhtranghd_id_foreign")]
    public partial class Donhang
    {
        public Donhang()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("donhang_nguoi_nhan")]
        [StringLength(100)]
        public string DonhangNguoiNhan { get; set; }
        [Required]
        [Column("donhang_nguoi_nhan_email")]
        [StringLength(255)]
        public string DonhangNguoiNhanEmail { get; set; }
        [Required]
        [Column("donhang_nguoi_nhan_sdt")]
        [StringLength(12)]
        public string DonhangNguoiNhanSdt { get; set; }
        [Required]
        [Column("donhang_nguoi_nhan_dia_chi")]
        [StringLength(200)]
        public string DonhangNguoiNhanDiaChi { get; set; }
        [Required]
        [Column("donhang_ghi_chu")]
        public string DonhangGhiChu { get; set; }
        [Column("donhang_tong_tien", TypeName = "decimal(10, 2)")]
        public decimal DonhangTongTien { get; set; }
        [Column("khachhang_id")]
        public long KhachhangId { get; set; }
        [Column("tinhtranghd_id")]
        public long TinhtranghdId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(KhachhangId))]
        [InverseProperty("Donhangs")]
        public virtual Khachhang Khachhang { get; set; }
        [ForeignKey(nameof(TinhtranghdId))]
        [InverseProperty("Donhangs")]
        public virtual Tinhtranghd Tinhtranghd { get; set; }
        [InverseProperty(nameof(Chitietdonhang.Donhang))]
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
