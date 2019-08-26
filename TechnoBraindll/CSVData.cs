using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBrainPrivacyCenterCandidate
{
    public class CSVData
    {
        public String employee { get; set; }
        public String Manager { get; set; }
        public int salary { get; set; }

        public CSVData(string employee, string manager, int salary)
        {
            this.employee = employee;
            Manager = manager;
            this.salary = salary;
        }
    }
}
