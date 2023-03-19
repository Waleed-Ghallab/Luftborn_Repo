using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelinterface.Core.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
