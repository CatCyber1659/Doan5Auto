using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("khachhang", Schema = "banhangnongsan")]
    [Index(nameof(KhachhangEmail), Name = "khachhang$khachhang_khachhang_email_unique", IsUnique = true)]
    [Index(nameof(UserId), Name = "khachhang_user_id_foreign")]
    public partial class Khachhang
    {
        public Khachhang()
        {
            Donhangs = new HashSet<Donhang>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("khachhang_ten")]
        [StringLength(100)]
        public string KhachhangTen { get; set; }
        [Required]
        [Column("khachhang_email")]
        [StringLength(255)]
        public string KhachhangEmail { get; set; }
        [Required]
        [Column("khachhang_sdt")]
        [StringLength(12)]
        public string KhachhangSdt { get; set; }
        [Required]
        [Column("khachhang_dia_chi")]
        [StringLength(200)]
        public string KhachhangDiaChi { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Khachhangs")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Donhang.Khachhang))]
        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}
