using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Doan5Auto.Models
{
    [Table("tuyendung", Schema = "banhangnongsan")]
    public partial class Tuyendung
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("tuyendung_tieu_de")]
        [StringLength(255)]
        public string TuyendungTieuDe { get; set; }
        [Required]
        [Column("tuyendung_url")]
        [StringLength(255)]
        public string TuyendungUrl { get; set; }
        [Required]
        [Column("tuyendung_anh")]
        [StringLength(255)]
        public string TuyendungAnh { get; set; }
        [Required]
        [Column("tuyendung_mo_ta")]
        public string TuyendungMoTa { get; set; }
        [Required]
        [Column("tuyendung_lien_he")]
        public string TuyendungLienHe { get; set; }
        [Column("tuyendung_thoi_gian")]
        public int TuyendungThoiGian { get; set; }
        [Column("tuyendung_tinh_trang")]
        public int? TuyendungTinhTrang { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
    }
}
