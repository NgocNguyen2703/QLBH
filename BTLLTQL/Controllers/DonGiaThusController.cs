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
    public class DonGiaThusController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: DonGiaThus
        public ActionResult Index()
        {
            return View(db.DonGiaThus.ToList());
        }

        // GET: DonGiaThus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGiaThu donGiaThu = db.DonGiaThus.Find(id);
            if (donGiaThu == null)
            {
                return HttpNotFound();
            }
            return View(donGiaThu);
        }

        // GET: DonGiaThus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonGiaThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuThu,IDDichVu,TenDV,DonGia")] DonGiaThu donGiaThu)
        {
            if (ModelState.IsValid)
            {
                db.DonGiaThus.Add(donGiaThu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donGiaThu);
        }

        // GET: DonGiaThus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGiaThu donGiaThu = db.DonGiaThus.Find(id);
            if (donGiaThu == null)
            {
                return HttpNotFound();
            }
            return View(donGiaThu);
        }

        // POST: DonGiaThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuThu,IDDichVu,TenDV,DonGia")] DonGiaThu donGiaThu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donGiaThu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donGiaThu);
        }

        // GET: DonGiaThus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonGiaThu donGiaThu = db.DonGiaThus.Find(id);
            if (donGiaThu == null)
            {
                return HttpNotFound();
            }
            return View(donGiaThu);
        }

        // POST: DonGiaThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonGiaThu donGiaThu = db.DonGiaThus.Find(id);
            db.DonGiaThus.Remove(donGiaThu);
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
