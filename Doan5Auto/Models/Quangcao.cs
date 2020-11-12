using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("quangcao", Schema = "banhangnongsan")]
    public partial class Quangcao
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("quangcao_anh")]
        [StringLength(255)]
        public string QuangcaoAnh { get; set; }
        [Column("quangcao_trang_thai")]
        public int QuangcaoTrangThai { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
