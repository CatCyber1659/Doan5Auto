using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("users", Schema = "banhangnongsan")]
    [Index(nameof(Email), Name = "users$users_email_unique", IsUnique = true)]
    [Index(nameof(LoainguoidungId), Name = "users_loainguoidung_id_foreign")]
    public partial class User
    {
        public User()
        {
            Khachhangs = new HashSet<Khachhang>();
            Nhanviens = new HashSet<Nhanvien>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(200)]
        public string Password { get; set; }
        [Column("loainguoidung_id")]
        public long LoainguoidungId { get; set; }
        [Column("remember_token")]
        [StringLength(100)]
        public string RememberToken { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(LoainguoidungId))]
        [InverseProperty("Users")]
        public virtual Loainguoidung Loainguoidung { get; set; }
        [InverseProperty(nameof(Khachhang.User))]
        public virtual ICollection<Khachhang> Khachhangs { get; set; }
        [InverseProperty(nameof(Nhanvien.User))]
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
