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
using System.Web.Security;
using BTLLTQL.Models;

namespace BTLLTQL.Controllers
{
    public class CasController : Controller
    {
        private BTLDbConText db = new BTLDbConText();
        [Authorize]
        public ActionResult Index(string searchString)
        {
            var cas = from l in db.Cas // lấy toàn bộ liên kết
                             select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                cas = cas.Where(s => s.Ngay.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(cas);
        }

        // GET: Cas/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ca ca = db.Cas.Find(id);
            if (ca == null)
            {
                return HttpNotFound();
            }
            return View(ca);
        }

        // GET: Cas/Create
       [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        public bool CheckCa(string ca)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BTLDbConText"].ConnectionString;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Cas where IDCa = @Ca", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Ca";
                    param.Value = ca;
                    cmd.Parameters.Add(param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        // POST: Cas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCa,Ngay,Gio")] Ca ca)
        {
            if (ModelState.IsValid)
            {
                if (CheckCa(ca.IDCa))
                {
                    ModelState.AddModelError("", "IDCa da ton tai");
                } else
                {
                    db.Cas.Add(ca);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(ca);
        }

        // GET: Cas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ca ca = db.Cas.Find(id);
            if (ca == null)
            {
                return HttpNotFound();
            }
            return View(ca);
        }

        // POST: Cas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCa,Ngay,Gio")] Ca ca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ca);
        }

        // GET: Cas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ca ca = db.Cas.Find(id);
            if (ca == null)
            {
                return HttpNotFound();
            }
            return View(ca);
        }

        // POST: Cas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ca ca = db.Cas.Find(id);
            db.Cas.Remove(ca);
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
