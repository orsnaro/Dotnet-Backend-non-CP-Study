using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Views {
    public class EmployeeRecordsView {

        private Employees _employees = null!;
        public EmployeeRecordsView(Employees employees) {
            _employees = employees;
        }

        public void RunRecordsView() {
            Console.WriteLine(EmployeeCommonOutputText.GetColumnHeadings());
            Console.WriteLine();

            foreach(Employee emp in _employees) {
                Console.Write(emp.GetEmployeeInformation());
            }
        }
    }
}
