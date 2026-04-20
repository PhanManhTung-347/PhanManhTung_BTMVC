using Microsoft.AspNetCore.Mvc;
using PMT_Baitap_MVCTaiLop.Models;

namespace PMT_Baitap_MVCTaiLop.Controllers
{
    public class KhoaHocsController : Controller
    {
        private readonly AppDbContext _db;
        public KhoaHocsController(AppDbContext db) => _db = db;

        public IActionResult Index() => View(_db.khoaHocs.ToList());
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(KhoaHoc kh)
        {
            _db.khoaHocs.Add(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) => View(_db.khoaHocs.Find(id));

        [HttpPost]
        public IActionResult Edit(KhoaHoc kh)
        {
            _db.khoaHocs.Update(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var kh = _db.khoaHocs.Find(id);
            if (kh != null) { _db.khoaHocs.Remove(kh); _db.SaveChanges(); }
            return RedirectToAction("Index");
        }
    }
}