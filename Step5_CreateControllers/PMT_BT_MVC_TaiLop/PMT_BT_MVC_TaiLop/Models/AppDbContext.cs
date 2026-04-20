using Microsoft.EntityFrameworkCore;
using PMT_Baitap_MVCTaiLop.Models;

namespace PMT_Baitap_MVCTaiLop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<KhoaHoc> khoaHocs { get; set; }
        public DbSet<GiaoVien> giaoViens { get; set; }
        public DbSet<LopHocPhan> lopHocPhans { get; set; }

        public DbSet<SinhVien> sinhViens { get; set; }
        public DbSet<DangKyLopHoc> dangKyLopHocs { get; set; }
    }
}
