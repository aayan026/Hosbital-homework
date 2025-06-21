using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosbital_homework.Models
{
    internal class Department
    {
        public string departmentName { get; set; }//   - Stamotologiya

        public List<Doctor> doctors { get; set; }// hemid, ilkin,naile 

        public Department(string departmentName)
        {
            this.departmentName = departmentName;
            doctors = new List<Doctor> { };
        }

        public override string ToString() => $@"
 ~ {departmentName}";
    }
}
