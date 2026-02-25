using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ASP.Net_MVC_Demo.Custom.Validation;

namespace ASP.Net_MVC_Demo.Models
{
    public class Employee
    {
        /// <summary>
        /// 数据表主键，自增
        /// </summary>
        [Key]
        public int EmployeeID { get; set; }

        [FirstNameValidation]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName { get; set; }

        public int Salary { get; set; }
    }
}