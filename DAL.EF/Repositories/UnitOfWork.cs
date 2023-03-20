using Modelinterface.Core.Interfaces;
using Modelinterface.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly App_dbcontext _context;
        
        public IBaseRepository<Employee> Employees { get; private set; }

        public IBaseRepository<Department> Departments { get; private set; }
        public UnitOfWork(App_dbcontext context)
        {
            _context = context;
            Employees = new BaseRepository<Employee>(_context);
            Departments = new BaseRepository<Department>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
