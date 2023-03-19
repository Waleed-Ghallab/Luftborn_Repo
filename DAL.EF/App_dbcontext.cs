using Microsoft.EntityFrameworkCore;
using Modelinterface.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class App_dbcontext:DbContext
    {
        public App_dbcontext(DbContextOptions<App_dbcontext> options) : base(options) { 

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
