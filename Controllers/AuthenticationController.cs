using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Net_MVC_Demo.Models;
using ASP.Net_MVC_Demo.BusinessLayer;
using System.Web.Security;

namespace ASP.Net_MVC_Demo.Controllers
{
    public class AuthenticationController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View("LoginView");
        }

        [HttpPost]
        public ActionResult DoLogin(User user)
        {
            if (ModelState.IsValid)
            {
                var employeeBusiness = new EmployeeBusiness();

                var status = employeeBusiness.GetUserValidity(user);
                if (status == UserStatus.UnAuthenticatedUser)
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("LoginView");
                }

                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["IsAdmin"] = status == UserStatus.AuthenticatedAdmin;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("LoginView");
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
