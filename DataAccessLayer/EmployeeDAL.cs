using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ASP.Net_MVC_Demo.Models;

namespace ASP.Net_MVC_Demo.DataAccessLayer
{
    public class EmployeeDAL : DbContext
    {
        public EmployeeDAL() : base("EmployeeDALConnection") { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TB_Employee");
            base.OnModelCreating(modelBuilder);
        }
    }
}