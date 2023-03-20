using Modelinterface.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelinterface.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Department> Departments { get; }
        int Complete();

    }
}
