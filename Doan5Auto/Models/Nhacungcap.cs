using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("nhacungcap", Schema = "banhangnongsan")]
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Lohangs = new HashSet<Lohang>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("nhacungcap_ten")]
        [StringLength(200)]
        public string NhacungcapTen { get; set; }
        [Required]
        [Column("nhacungcap_dia_chi")]
        [StringLength(200)]
        public string NhacungcapDiaChi { get; set; }
        [Required]
        [Column("nhacungcap_sdt")]
        [StringLength(12)]
        public string NhacungcapSdt { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty(nameof(Lohang.Nhacungcap))]
        public virtual ICollection<Lohang> Lohangs { get; set; }
    }
}
