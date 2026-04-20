using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DangKyLopHocsController : Controller
    {
        private readonly AppDbContext _db;
        public DangKyLopHocsController(AppDbContext db) => _db = db;

        public IActionResult Index() => View(_db.dangKyLopHocs.Include(d => d.SinhVien).Include(d => d.LopHocPhan).ToList());

        public IActionResult Create()
        {
            ViewBag.SinhVienId = new SelectList(_db.sinhViens, "SinhVienId", "tenSinhVien");
            ViewBag.LopHocPhanId = new SelectList(_db.lopHocPhans, "LopHocPhanId", "tenLop");
            return View();
        }

        [HttpPost]
        public IActionResult Create(DangKyLopHoc dk)
        {
            dk.ngaydk = DateTime.Now; 
            _db.dangKyLopHocs.Add(dk);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var dk = _db.dangKyLopHocs.Find(id);
            ViewBag.SinhVienId = new SelectList(_db.sinhViens, "SinhVienId", "tenSinhVien", dk.SinhVienId);
            ViewBag.LopHocPhanId = new SelectList(_db.lopHocPhans, "LopHocPhanId", "tenLop", dk.LopHocPhanId);
            return View(dk);
        }

        [HttpPost]
        public IActionResult Edit(DangKyLopHoc dk)
        {
            _db.dangKyLopHocs.Update(dk);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var dk = _db.dangKyLopHocs.Find(id);
            if (dk != null) { _db.dangKyLopHocs.Remove(dk); _db.SaveChanges(); }
            return RedirectToAction("Index");
        }
    }
}