using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hosbital_homework.Models
{
    internal class Doctor
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int workExperienceYear { get; set; }
        public Department department { get; set; }
        public List<ReceptionHour> receptionHours { get; set; }

        public Doctor(string name, string surname, int workExperienceYear, Department department)
        {
            this.name = name;
            this.surname = surname;
            this.workExperienceYear = workExperienceYear;
            this.department = department;
            receptionHours = new List<ReceptionHour>
            {
                new ReceptionHour("09:00","11:00"),
                new ReceptionHour("12:00","14:00"),
                new ReceptionHour("15:00","17:00")
            };
            department.doctors.Add(this);
        }

        public void ReserveHour(int index)
        {
            var reserved = receptionHours[index];
            reserved.isReserved = true;
        }
        public void PrintReceptionHour()
        {
            for (int i = 0; i < receptionHours.Count; i++)
            {
                Console.WriteLine("");
            }
        }
        public override string ToString() => $@" | Name: {name}
 | Surname: {surname}
 | Experience Year: {workExperienceYear} years
---------------------------------------------------------------";
    }
}
