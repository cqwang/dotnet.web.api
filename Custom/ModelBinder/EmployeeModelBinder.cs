using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotnet.web.api
{
    public class EmployeeModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            Employee employee = new Employee();
            employee.FirstName = controllerContext.RequestContext.HttpContext.Request.Form["FirstName"];
            employee.LastName = controllerContext.RequestContext.HttpContext.Request.Form["LastName"];
            employee.Salary = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["Salary"]);
            return employee;
        }
    }
}