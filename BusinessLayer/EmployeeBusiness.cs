using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ASP.Net_MVC_Demo.Models;
using ASP.Net_MVC_Demo.DataAccessLayer;

namespace ASP.Net_MVC_Demo.BusinessLayer
{
    public class EmployeeBusiness
    {
        public List<Employee> GetEmployees()
        {
            var employeeDAL = new EmployeeDAL();
            return employeeDAL.Employees.ToList();
        }

        public Employee SaveEmployee(Employee employee)
        {
            var employeeDAL = new EmployeeDAL();
            employeeDAL.Employees.Add(employee);
            employeeDAL.SaveChanges();
            return employee;
        }

        public UserStatus GetUserValidity(User user)
        {
            if (user.UserName == "Admin" && user.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (user.UserName == "User" && user.Password == "User")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.UnAuthenticatedUser;
            }
        }

        public void UploadEmployees(List<Employee> employees)
        {
            var employeeDAL = new EmployeeDAL();
            employees.ForEach(p => employeeDAL.Employees.Add(p));
            employeeDAL.SaveChanges();
        }
    }
}