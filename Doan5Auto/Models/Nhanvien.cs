using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("nhanvien", Schema = "banhangnongsan")]
    [Index(nameof(NhanvienCmnd), Name = "nhanvien$nhanvien_nhanvien_cmnd_unique", IsUnique = true)]
    [Index(nameof(UserId), Name = "nhanvien_user_id_foreign")]
    public partial class Nhanvien
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nhanvien_ten")]
        [StringLength(100)]
        public string NhanvienTen { get; set; }
        [Required]
        [Column("nhanvien_cmnd")]
        [StringLength(12)]
        public string NhanvienCmnd { get; set; }
        [Required]
        [Column("nhanvien_sdt")]
        [StringLength(12)]
        public string NhanvienSdt { get; set; }
        [Required]
        [Column("nhanvien_dia_chi")]
        [StringLength(200)]
        public string NhanvienDiaChi { get; set; }
        [Column("nhanvien_ngay_vao_lam", TypeName = "date")]
        public DateTime NhanvienNgayVaoLam { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Nhanviens")]
        public virtual User User { get; set; }
    }
}
