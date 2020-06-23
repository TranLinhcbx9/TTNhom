using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Title = "Index admin";
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Admin Login";
            return View();
        }
        public ActionResult Logup()
        {
            ViewBag.Title = "user logup as admin";
            return View();
        }
        public ActionResult Logout()
        {
            ViewBag.Title = "Admin out";
            Session["username"] = null;
            return Redirect("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ViewBag.Title = "Admin Login " + username;
            UserDao dao = new UserDao();
            if (dao.checkLogin(username, password) == true)
            {
                Session["username"] = username;
                return Redirect("/Product/Index");
            }
            else
                return View();
        }
        [HttpPost]
        public ActionResult Logup(string username, string password)
        {
            ViewBag.Title = "Admin Logup";
            return Redirect("Logup");
        }
    }
}