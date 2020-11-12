using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("sanpham", Schema = "banhangnongsan")]
    [Index(nameof(DonvitinhId), Name = "sanpham_donvitinh_id_foreign")]
    [Index(nameof(LoaisanphamId), Name = "sanpham_loaisanpham_id_foreign")]
    public partial class Sanpham
    {
        public Sanpham()
        {
            Binhluans = new HashSet<Binhluan>();
            Chitietdonhangs = new HashSet<Chitietdonhang>();
            Lohangs = new HashSet<Lohang>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("sanpham_ky_hieu")]
        [StringLength(255)]
        public string SanphamKyHieu { get; set; }
        [Required]
        [Column("sanpham_ten")]
        [StringLength(255)]
        public string SanphamTen { get; set; }
        [Required]
        [Column("sanpham_gia")]
        [StringLength(255)]
        public string SanphamGia { get; set; }
        [Required]
        [Column("sanpham_anh")]
        [StringLength(255)]
        public string SanphamAnh { get; set; }
        [Required]
        [Column("sanpham_mo_ta")]
        public string SanphamMoTa { get; set; }
        [Column("loaisanpham_id")]
        public long LoaisanphamId { get; set; }
        [Column("donvitinh_id")]
        public long DonvitinhId { get; set; }
        [Column("sanpham_khuyenmai")]
        public int SanphamKhuyenmai { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(LoaisanphamId))]
        [InverseProperty("Sanphams")]
        public virtual Loaisanpham Loaisanpham { get; set; }
        [InverseProperty(nameof(Binhluan.Sanpham))]
        public virtual ICollection<Binhluan> Binhluans { get; set; }
        [InverseProperty(nameof(Chitietdonhang.Sanpham))]
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
        [InverseProperty(nameof(Lohang.Sanpham))]
        public virtual ICollection<Lohang> Lohangs { get; set; }
    }
}
