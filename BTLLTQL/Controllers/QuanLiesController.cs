using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            var quanLies = from l in db.QuanLys // lấy toàn bộ liên kết
                            select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                quanLies = quanLies.Where(s => s.IDNhanVien.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(quanLies);
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
        public bool CheckQuanLy(string quanly)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BTLDbConText"].ConnectionString;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from QuanLys where IDNhanVien = @NhanVien", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@NhanVien";
                    param.Value = quanly;
                    cmd.Parameters.Add(param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
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
                if (CheckQuanLy(quanLy.IDNhanVien))
                {
                    ModelState.AddModelError("", "IDNhanVien da ton tai");
                }
                else
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
