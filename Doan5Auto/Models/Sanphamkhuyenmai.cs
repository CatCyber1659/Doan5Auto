using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Keyless]
    [Table("sanphamkhuyenmai", Schema = "banhangnongsan")]
    [Index(nameof(KhuyenmaiId), Name = "sanphamkhuyenmai_khuyenmai_id_foreign")]
    [Index(nameof(SanphamId), Name = "sanphamkhuyenmai_sanpham_id_foreign")]
    public partial class Sanphamkhuyenmai
    {
        [Column("khuyenmai_id")]
        public long KhuyenmaiId { get; set; }
        [Column("sanpham_id")]
        public long SanphamId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(SanphamId))]
        public virtual Sanpham Sanpham { get; set; }
    }
}
