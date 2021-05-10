using BTLLTQL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BTLLTQL.Controllers
{
    public class CheckAccountController : Controller
    {
        Encrytion encry = new Encrytion();
        BTLDbConText db = new BTLDbConText();
        //Mặc định là get
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Nhận DL từ client gửi lên
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CheckAccount Checkacc)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = encry.PasswordEncrytion(Checkacc.CheckPassword);
                var model = db.CheckAccounts.Where(m => m.CheckUsername == Checkacc.CheckUsername && m.CheckPassword == encrytionpass).ToList().Count();
                //Thong tin dang nhap chinh xac
                if (model == 1)
                {
                    FormsAuthentication.SetAuthCookie(Checkacc.CheckUsername, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thong tin dang nhap khong chinh xac");
                }
            }
            return View(Checkacc);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CheckAccount Checkacc)
        {
            if (ModelState.IsValid)
            {
                //Ma hoa mat khau truoc khi luu vao database
                Checkacc.CheckPassword = encry.PasswordEncrytion(Checkacc.CheckPassword);
                if (CheckUsername(Checkacc.CheckUsername)) {
                    ModelState.AddModelError("", "Tai khoan da ton tai");
                } else
                {
                    db.CheckAccounts.Add(Checkacc);
                    db.SaveChanges();
                    return RedirectToAction("Login", "CheckAccount");
                }
            }
            return View(Checkacc);
        }
        //Kiem tra username da ton tai trong he thong chua
        public bool CheckUsername(string username)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["BTLDbConText"].ConnectionString;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from CheckAccounts where CheckUsername = @Username", con))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Username";
                    param.Value = username;
                    cmd.Parameters.Add(param);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        //Hàm đăng xuất khỏi chương trình
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //Kiểm tra xem returnUrl có thuộc hệ thống hay không
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}