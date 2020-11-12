using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("binhluan", Schema = "banhangnongsan")]
    [Index(nameof(SanphamId), Name = "binhluan_sanpham_id_foreign")]
    public partial class Binhluan
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("binhluan_ten")]
        [StringLength(100)]
        public string BinhluanTen { get; set; }
        [Required]
        [Column("binhluan_email")]
        [StringLength(255)]
        public string BinhluanEmail { get; set; }
        [Required]
        [Column("binhluan_noi_dung")]
        public string BinhluanNoiDung { get; set; }
        [Column("binhluan_trang_thai")]
        public int BinhluanTrangThai { get; set; }
        [Column("sanpham_id")]
        public long SanphamId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(SanphamId))]
        [InverseProperty("Binhluans")]
        public virtual Sanpham Sanpham { get; set; }
    }
}
