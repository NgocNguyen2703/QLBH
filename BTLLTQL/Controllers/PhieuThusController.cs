using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLLTQL.Models;

namespace BTLLTQL.Controllers
{
    public class PhieuThusController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: PhieuThus
        [Authorize]
        public ActionResult Index()
        {
            return View(db.PhieuThus.ToList());
        }

        // GET: PhieuThus/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return HttpNotFound();
            }
            return View(phieuThu);
        }

        // GET: PhieuThus/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuThu,IDKhachHang,Ngay,IDNhanVien,TongTien")] PhieuThu phieuThu)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThus.Add(phieuThu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuThu);
        }

        // GET: PhieuThus/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return HttpNotFound();
            }
            return View(phieuThu);
        }

        // POST: PhieuThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuThu,IDKhachHang,Ngay,IDNhanVien,TongTien")] PhieuThu phieuThu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuThu);
        }

        // GET: PhieuThus/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return HttpNotFound();
            }
            return View(phieuThu);
        }

        // POST: PhieuThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            db.PhieuThus.Remove(phieuThu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
