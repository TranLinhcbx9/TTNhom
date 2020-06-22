using ShopOnline.Areas.Admin.Models;
using ShopOnline.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Model.Dao;
using Model.EF;
using System.Web.Mvc;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result == null)
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
                else
                {
                    var user = new UserDao().GetById(model.UserName);
                  
                    var userSession = new UserLogin();
                    User user1 = (User)user;
                    userSession.UserName = user1.UserName;
                    userSession.UserID = user1.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
        }
    }

    internal class UserDao
    {
        public UserDao()
        {
        }

        internal object GetById(string userName)
        {
            throw new NotImplementedException();
        }

        internal object Login(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}