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
    [Authorize]
    public class BansController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: Bans
        public ActionResult Index(string searchString)
        {
            var bans = from l in db.Bans // lấy toàn bộ liên kết
                      select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                bans = bans.Where(s => s.SoBan.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(bans);
        }

        // GET: Bans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return HttpNotFound();
            }
            return View(ban);
        }

        // GET: Bans/Create
        public ActionResult Create()
        {
            return View();
        }
        public bool CheckBan(string ban)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BTLDbConText"].ConnectionString;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Bans where IDBan = @Ban", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Ban";
                    param.Value = ban;
                    cmd.Parameters.Add(param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        // POST: Bans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBan,SoBan")] Ban ban)
        {
            if (ModelState.IsValid)
                if (CheckBan(ban.IDBan))
                {
                    ModelState.AddModelError("", "IDBan da ton tai");
                }
                else
                {
                db.Bans.Add(ban);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            return View(ban);
        }

        // GET: Bans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return HttpNotFound();
            }
            return View(ban);
        }

        // POST: Bans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBan,SoBan")] Ban ban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ban);
        }

        // GET: Bans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ban ban = db.Bans.Find(id);
            if (ban == null)
            {
                return HttpNotFound();
            }
            return View(ban);
        }

        // POST: Bans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ban ban = db.Bans.Find(id);
            db.Bans.Remove(ban);
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
