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
    public class DonGiaChisController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: DonGiaChis
        public ActionResult Index()
        {
            return View(db.DonGiaChis.ToList());
        }

        // GET: DonGiaChis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGiaChi donGiaChi = db.DonGiaChis.Find(id);
            if (donGiaChi == null)
            {
                return HttpNotFound();
            }
            return View(donGiaChi);
        }

        // GET: DonGiaChis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonGiaChis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuChi,IDDonHang,TongTienHang")] DonGiaChi donGiaChi)
        {
            if (ModelState.IsValid)
            {
                db.DonGiaChis.Add(donGiaChi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donGiaChi);
        }

        // GET: DonGiaChis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGiaChi donGiaChi = db.DonGiaChis.Find(id);
            if (donGiaChi == null)
            {
                return HttpNotFound();
            }
            return View(donGiaChi);
        }

        // POST: DonGiaChis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuChi,IDDonHang,TongTienHang")] DonGiaChi donGiaChi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donGiaChi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donGiaChi);
        }

        // GET: DonGiaChis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGiaChi donGiaChi = db.DonGiaChis.Find(id);
            if (donGiaChi == null)
            {
                return HttpNotFound();
            }
            return View(donGiaChi);
        }

        // POST: DonGiaChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonGiaChi donGiaChi = db.DonGiaChis.Find(id);
            db.DonGiaChis.Remove(donGiaChi);
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
