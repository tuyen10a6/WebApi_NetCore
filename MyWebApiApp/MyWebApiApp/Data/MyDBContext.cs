using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDBContext: DbContext
    {
        public MyDBContext (DbContextOptions options): base(options)
        { }
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> donHangChiTiets { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDh, e.MaHH });

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.donHangChiTiets)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
               .WithMany(e => e.DonHangChiTiets)
               .HasForeignKey(e => e.MaHH)
               .HasConstraintName("FK_DonHangCT_HangHoa");

            });
        }

    }
}
