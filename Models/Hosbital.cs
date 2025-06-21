using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosbital_homework.Models
{
    internal class Hosbital
    {
        public List<Department> departments { get; set; }
        public Hosbital(List<Department> departments)
        {
            this.departments = departments;
        }

    }
}
