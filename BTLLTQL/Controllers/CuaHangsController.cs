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
    public class CuaHangsController : Controller
    {
        private BTLDbConText db = new BTLDbConText();

        // GET: CuaHangs
        public ActionResult Index(string searchString)
        {
            var cuaHangs  = from l in db.CuaHangs // lấy toàn bộ liên kết
                            select l;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                cuaHangs = cuaHangs.Where(s => s.ChiNhanh.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }
            return View(cuaHangs);
        }

        // GET: CuaHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }

        // GET: CuaHangs/Create
        public ActionResult Create()
        {
            return View();
        }
        public bool CheckCuaHang(string cuaHang)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BTLDbConText"].ConnectionString;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from CuaHangs where IDCuaHang = @CuaHang", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@CuaHang";
                    param.Value = cuaHang;
                    cmd.Parameters.Add(param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        // POST: CuaHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCuaHang,TenCuaHang,ChiNhanh")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
                if (CheckCuaHang(cuaHang.IDCuaHang))
                {
                    ModelState.AddModelError("", "IDCuaHang da ton tai");
                }
                else
                {
                db.CuaHangs.Add(cuaHang);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            return View(cuaHang);
        }

        // GET: CuaHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }

        // POST: CuaHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCuaHang,TenCuaHang,ChiNhanh")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuaHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuaHang);
        }

        // GET: CuaHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return HttpNotFound();
            }
            return View(cuaHang);
        }

        // POST: CuaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CuaHang cuaHang = db.CuaHangs.Find(id);
            db.CuaHangs.Remove(cuaHang);
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
