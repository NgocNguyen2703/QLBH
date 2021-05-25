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
    public class PhieuThusController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: PhieuThus
        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            var phieuThus = from l in db.PhieuThus // lấy toàn bộ liên kết
                       select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                phieuThus = phieuThus.Where(s => s.Ngay.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(phieuThus);
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
        public bool CheckPhieuThu(string phieuThu)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BTLDbConText"].ConnectionString;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from PhieuThus where IDPhieuThu = @PhieuThu", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@PhieuThu";
                    param.Value = phieuThu;
                    cmd.Parameters.Add(param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
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
                if (CheckPhieuThu(phieuThu.IDPhieuThu))
                {
                    ModelState.AddModelError("", "IDPhieuThu da ton tai");
                }
                else
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
