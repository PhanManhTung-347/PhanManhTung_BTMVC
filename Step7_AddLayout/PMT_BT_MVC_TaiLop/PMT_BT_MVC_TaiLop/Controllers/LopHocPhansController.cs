using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMT_Baitap_MVCTaiLop.Models;

namespace PMT_Baitap_MVCTaiLop.Controllers
{
    public class LopHocPhansController : Controller
    {
        private readonly AppDbContext _db;
        public LopHocPhansController(AppDbContext db) => _db = db;

        public IActionResult Index() => View(_db.lopHocPhans.Include(l => l.GiaoVien).Include(l => l.KhoaHoc).ToList());

        public IActionResult Create()
        {
            ViewBag.GiaoVienId = new SelectList(_db.giaoViens, "GiaoVienId", "tenGV");
            ViewBag.KhoaHocId = new SelectList(_db.khoaHocs, "KhoaHocId", "tenKH");
            return View();
        }

        [HttpPost]
        public IActionResult Create(LopHocPhan lhp)
        {
            _db.lopHocPhans.Add(lhp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var lhp = _db.lopHocPhans.Find(id);
            ViewBag.GiaoVienId = new SelectList(_db.giaoViens, "GiaoVienId", "tenGV", lhp.GiaoVienId);
            ViewBag.KhoaHocId = new SelectList(_db.khoaHocs, "KhoaHocId", "tenKH", lhp.KhoaHocId);
            return View(lhp);
        }

        [HttpPost]
        public IActionResult Edit(LopHocPhan lhp)
        {
            _db.lopHocPhans.Update(lhp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var lhp = _db.lopHocPhans.Find(id);
            if (lhp != null) { _db.lopHocPhans.Remove(lhp); _db.SaveChanges(); }
            return RedirectToAction("Index");
        }
    }
}