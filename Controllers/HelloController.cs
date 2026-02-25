using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Net_MVC_Demo.Models;

namespace ASP.Net_MVC_Demo.Controllers
{
    public class HelloController : Controller
    {
        public string GetRemark()
        {
            return "Hello,Controller";
        }

        [NonAction]
        public bool IsValid(int id)
        {
            return false;
        }

        public ActionResult GetView()
        {
            if (DateTime.Now.Second < 20)
            {
                return View("StaticDataView");
            }
            else if (DateTime.Now.Second < 40)
            {
                var employee = new Employee() { FirstName = "张", LastName = "三", Salary = 2000 };
                ViewData["Employee"] = employee; //或者 ViewBag.Employee = employee;

                return View("DynamicDataViewData_ViewBag_View");
            }
            else
            {
                var employee = new Employee() { FirstName = "张", LastName = "三", Salary = 2000 };
                return View("DynamicDataStrongType_View", employee);
            }
        }
    }
}
