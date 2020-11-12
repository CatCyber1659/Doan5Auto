using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Doan5Auto.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Binhluan> Binhluans { get; set; }
        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Loainguoidung> Loainguoidungs { get; set; }
        public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }
        public virtual DbSet<Lohang> Lohangs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Nhom> Nhoms { get; set; }
        public virtual DbSet<Quangcao> Quangcaos { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Sanphamkhuyenmai> Sanphamkhuyenmais { get; set; }
        public virtual DbSet<Tinhtranghd> Tinhtranghds { get; set; }
        public virtual DbSet<Tuyendung> Tuyendungs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=NongSanSach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Binhluan>(entity =>
            {
                entity.HasOne(d => d.Sanpham)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.SanphamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("binhluan$binhluan_sanpham_id_foreign");
            });

            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.HasOne(d => d.Donhang)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.DonhangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chitietdonhang$chitietdonhang_donhang_id_foreign");

                entity.HasOne(d => d.Sanpham)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.SanphamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chitietdonhang$chitietdonhang_sanpham_id_foreign");
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.HasOne(d => d.Khachhang)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.KhachhangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("donhang$donhang_khachhang_id_foreign");

                entity.HasOne(d => d.Tinhtranghd)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.TinhtranghdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("donhang$donhang_tinhtranghd_id_foreign");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("khachhang$khachhang_user_id_foreign");
            });

            modelBuilder.Entity<Loaisanpham>(entity =>
            {
                entity.HasOne(d => d.Nhom)
                    .WithMany(p => p.Loaisanphams)
                    .HasForeignKey(d => d.NhomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("loaisanpham$loaisanpham_nhom_id_foreign");
            });

            modelBuilder.Entity<Lohang>(entity =>
            {
                entity.HasOne(d => d.Nhacungcap)
                    .WithMany(p => p.Lohangs)
                    .HasForeignKey(d => d.NhacungcapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lohang$lohang_nhacungcap_id_foreign");

                entity.HasOne(d => d.Sanpham)
                    .WithMany(p => p.Lohangs)
                    .HasForeignKey(d => d.SanphamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lohang$lohang_sanpham_id_foreign");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nhanvien$nhanvien_user_id_foreign");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasOne(d => d.Loaisanpham)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.LoaisanphamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sanpham$sanpham_loaisanpham_id_foreign");
            });

            modelBuilder.Entity<Sanphamkhuyenmai>(entity =>
            {
                entity.HasOne(d => d.Sanpham)
                    .WithMany()
                    .HasForeignKey(d => d.SanphamId)
                    .HasConstraintName("sanphamkhuyenmai$sanphamkhuyenmai_sanpham_id_foreign");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.Loainguoidung)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LoainguoidungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users$users_loainguoidung_id_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
