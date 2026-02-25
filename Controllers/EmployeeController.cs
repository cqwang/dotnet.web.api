using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Net_MVC_Demo.Models;
using ASP.Net_MVC_Demo.ViewModels;
using ASP.Net_MVC_Demo.BusinessLayer;
using ASP.Net_MVC_Demo.Custom.ModelBinder;
using ASP.Net_MVC_Demo.Custom.Filters;

namespace ASP.Net_MVC_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            var employeeBusiness = new EmployeeBusiness();
            var employees = employeeBusiness.GetEmployees();
            if (employees == null || employees.Count == 0)
            {
                return null;
            }

            var list = new List<EmployeeViewMode>();
            foreach (var employee in employees)
            {
                var employeeViewMode = new EmployeeViewMode();
                employeeViewMode.EmployeeName = employee.FirstName + " " + employee.LastName;
                employeeViewMode.Salary = employee.Salary.ToString("C");
                if (employee.Salary > 15000)
                {
                    employeeViewMode.SalaryColor = "yellow";
                }
                else
                {
                    employeeViewMode.SalaryColor = "green";
                }
                list.Add(employeeViewMode);
            }

            var viewModel = new EmployeeListViewModel();
            viewModel.Employees = list;
            //viewModel.UserName = User.Identity.Name;
            //viewModel.FooterData = new FooterViewModel();
            //viewModel.FooterData.CompanyName = "StepByStepSchools";
            //viewModel.FooterData.Year = DateTime.Now.Year.ToString();
            return View("IndexView", viewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            var model = new CreateEmployeeViewModel();
            //model.FooterData = new FooterViewModel();
            //model.FooterData.CompanyName = "StepByStepSchools";
            //model.FooterData.Year = DateTime.Now.Year.ToString();
            //model.UserName = User.Identity.Name;
            return View("CreateEmployeeView", new CreateEmployeeViewModel());
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        var employeeBusiness = new EmployeeBusiness();
                        employeeBusiness.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var createEmployeeViewModel = new CreateEmployeeViewModel();
                        createEmployeeViewModel.FirstName = e.FirstName;
                        createEmployeeViewModel.LastName = e.LastName;
                        if (e.Salary > 0)
                        {
                            createEmployeeViewModel.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            createEmployeeViewModel.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        //createEmployeeViewModel.FooterData = new FooterViewModel();
                        //createEmployeeViewModel.FooterData.CompanyName = "StepByStepSchools";
                        //createEmployeeViewModel.FooterData.Year = DateTime.Now.Year.ToString();
                        //createEmployeeViewModel.UserName = User.Identity.Name;
                        return View("CreateEmployeeView", createEmployeeViewModel);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
                default:
                    return new EmptyResult();
            }
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return View("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
