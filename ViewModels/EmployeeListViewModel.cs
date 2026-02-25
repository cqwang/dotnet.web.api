using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_MVC_Demo.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public List<EmployeeViewMode> Employees { get; set; }
    }
}