using WebApplication7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplikasiSederhana.Controllers
{
    [Authorize]
    public class MahasiswaController : Controller
    {
        public ActionResult Index()
        {
            List<Siswa> r;
            using (var s = new Siswa_DBEntities())
            {
                r = s.Siswa.ToList();
            }
            return View(r);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var model = new Siswa();
            TryUpdateModel(model);
            using (var s = new Siswa_DBEntities())
            {
                s.Siswa.Add(model);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        
        [ActionName("Edit")]
        public ActionResult Edit_Get(string nim)
        {
            var model = new Siswa();
            TryUpdateModel(model);
            using (var s = new Siswa_DBEntities())
            {
                model = s.Siswa.Where(x => x.NIM == nim).FirstOrDefault();

            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string nim)
        {
            var model = new Siswa();
            TryUpdateModel(model);
            using (var s = new Siswa_DBEntities())
            {
                var m = s.Siswa.Where(x => x.NIM == nim).FirstOrDefault();
                TryUpdateModel(m);
                s.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string nim)
        {
            var model = new Siswa();
            TryUpdateModel(model);
            using (var s = new Siswa_DBEntities())
            {
                model = s.Siswa.FirstOrDefault(x => x.NIM == nim);
            }
            return View(model);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string nim)
        {
            var model = new Siswa();
            TryUpdateModel(model);
            using (var s = new Siswa_DBEntities())
            {
                model = s.Siswa.FirstOrDefault(x => x.NIM == nim);
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string nim)
        {
            var model = new Siswa();
            TryUpdateModel(model);
            using (var s = new Siswa_DBEntities())
            {
                var m = s.Siswa.Remove(s.Siswa.FirstOrDefault(x => x.NIM == nim));
                TryUpdateModel(m);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
