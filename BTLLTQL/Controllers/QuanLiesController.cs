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
    public class QuanLiesController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: QuanLies
        [Authorize]
        public ActionResult Index()
        {
            return View(db.QuanLys.ToList());
        }

        // GET: QuanLies/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLy quanLy = db.QuanLys.Find(id);
            if (quanLy == null)
            {
                return HttpNotFound();
            }
            return View(quanLy);
        }

        // GET: QuanLies/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNhanVien,IDBan,IDCa")] QuanLy quanLy)
        {
            if (ModelState.IsValid)
            {
                db.QuanLys.Add(quanLy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quanLy);
        }

        // GET: QuanLies/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLy quanLy = db.QuanLys.Find(id);
            if (quanLy == null)
            {
                return HttpNotFound();
            }
            return View(quanLy);
        }

        // POST: QuanLies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhanVien,IDBan,IDCa")] QuanLy quanLy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanLy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanLy);
        }

        // GET: QuanLies/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLy quanLy = db.QuanLys.Find(id);
            if (quanLy == null)
            {
                return HttpNotFound();
            }
            return View(quanLy);
        }

        // POST: QuanLies/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanLy quanLy = db.QuanLys.Find(id);
            db.QuanLys.Remove(quanLy);
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
