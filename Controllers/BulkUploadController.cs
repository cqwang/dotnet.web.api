using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Net_MVC_Demo.Custom.Filters;
using ASP.Net_MVC_Demo.ViewModels;
using ASP.Net_MVC_Demo.Models;
using ASP.Net_MVC_Demo.BusinessLayer;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ASP.Net_MVC_Demo.Controllers
{
    public class BulkUploadController : AsyncController
    {
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        //[AdminFilter]
        //public async Task<ActionResult> Upload(FileUploadViewModel model)
        //{
        //    int t1 = Thread.CurrentThread.ManagedThreadId;
        //    List<Employee> employees = await Task.Factory.StartNew<List<Employee>>(() => GetEmployees(model));
        //    int t2 = Thread.CurrentThread.ManagedThreadId;
        //    EmployeeBusiness bal = new EmployeeBusiness();
        //    bal.UploadEmployees(employees);
        //    return RedirectToAction("Index", "Employee");
        //}

        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');//Values are comma separated
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);
                employees.Add(e);
            }
            return employees;
        }
    }
}
