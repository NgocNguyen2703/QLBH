using BTLLTQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BTLLTQL.Controllers
{
    public class CheckAccountController : Controller
    {
        //Mặc định là get
        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        //Nhận DL từ client gửi lên
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CheckAccount Checkacc, String returnUrl)
        {
            //Nếu vượt qua được Validation ở accountmodel
            if (Checkacc.CheckUsername == "admin" && Checkacc.CheckPassword == "123123")
            {
                //Set Cookie
                FormsAuthentication.SetAuthCookie(Checkacc.CheckUsername, true);
                return RedirectToLocal(returnUrl);
            }
            return View(Checkacc);
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