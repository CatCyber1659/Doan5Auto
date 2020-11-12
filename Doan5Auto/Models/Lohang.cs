using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("lohang", Schema = "banhangnongsan")]
    [Index(nameof(NhacungcapId), Name = "lohang_nhacungcap_id_foreign")]
    [Index(nameof(SanphamId), Name = "lohang_sanpham_id_foreign")]
    public partial class Lohang
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("lohang_ky_hieu")]
        [StringLength(200)]
        public string LohangKyHieu { get; set; }
        [Column("lohang_han_su_dung")]
        public int LohangHanSuDung { get; set; }
        [Column("lohang_gia_mua_vao", TypeName = "decimal(10, 2)")]
        public decimal LohangGiaMuaVao { get; set; }
        [Column("lohang_gia_ban_ra", TypeName = "decimal(10, 2)")]
        public decimal LohangGiaBanRa { get; set; }
        [Column("lohang_so_luong_nhap")]
        public int LohangSoLuongNhap { get; set; }
        [Column("lohang_so_luong_da_ban")]
        public int LohangSoLuongDaBan { get; set; }
        [Column("lohang_so_luong_doi_tra")]
        public int LohangSoLuongDoiTra { get; set; }
        [Column("lohang_so_luong_hien_tai")]
        public int LohangSoLuongHienTai { get; set; }
        [Column("lohang_tinh_trang")]
        public int? LohangTinhTrang { get; set; }
        [Column("sanpham_id")]
        public long SanphamId { get; set; }
        [Column("nhacungcap_id")]
        public long NhacungcapId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(NhacungcapId))]
        [InverseProperty("Lohangs")]
        public virtual Nhacungcap Nhacungcap { get; set; }
        [ForeignKey(nameof(SanphamId))]
        [InverseProperty("Lohangs")]
        public virtual Sanpham Sanpham { get; set; }
    }
}
