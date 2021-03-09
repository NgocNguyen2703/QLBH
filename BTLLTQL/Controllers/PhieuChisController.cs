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
    public class PhieuChisController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: PhieuChis
        public ActionResult Index()
        {
            return View(db.PhieuChis.ToList());
        }

        // GET: PhieuChis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            if (phieuChi == null)
            {
                return HttpNotFound();
            }
            return View(phieuChi);
        }

        // GET: PhieuChis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuChis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuChi,IDNhanVien,IDCuaHang,Ngay,Tongtienchi")] PhieuChi phieuChi)
        {
            if (ModelState.IsValid)
            {
                db.PhieuChis.Add(phieuChi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuChi);
        }

        // GET: PhieuChis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            if (phieuChi == null)
            {
                return HttpNotFound();
            }
            return View(phieuChi);
        }

        // POST: PhieuChis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuChi,IDNhanVien,IDCuaHang,Ngay,Tongtienchi")] PhieuChi phieuChi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuChi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuChi);
        }

        // GET: PhieuChis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            if (phieuChi == null)
            {
                return HttpNotFound();
            }
            return View(phieuChi);
        }

        // POST: PhieuChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            db.PhieuChis.Remove(phieuChi);
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
