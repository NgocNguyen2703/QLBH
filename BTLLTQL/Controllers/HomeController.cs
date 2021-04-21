using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLLTQL.Controllers
{
    public class HomeController : Controller
    {
        //Đối với action cho phép truy cập không cần kiểm tra đăng nhập thì viết
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        //Muốn kiển tra đăng nhập trước khi truy cập với action nào thì viết
        [Authorize] //Có thể kiểm tra với cả controller
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}