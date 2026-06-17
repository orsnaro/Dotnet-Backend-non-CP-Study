using EmployeeComponent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace EmployeeComponent.Views {
    public class EmployeeUpdateView {

        private Employees _employees = null!;

        public EmployeeUpdateView(Employees employees) {
            _employees = employees;
        }

        public void RunUpdateView() {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the Id of the employee you wish to edit.");

            int id = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());

            int index = _employees.Find(id);

            if (index != -1) {
                string firstName = string.Empty;
                string lastName = string.Empty;
                string annualSalary = string.Empty;
                string gender = string.Empty;
                string isManager = string.Empty;

                Employee employee = _employees[index];

                Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());
                Console.WriteLine(EmployeeCommonOutputText.GetUpdateViewAdditionalInstructions());

                Console.Write($"First Name ({employee.FirstName}): ");
                firstName = Console.ReadLine()!;

                Console.Write($"Last Name ({employee.LastName}): ");
                lastName = Console.ReadLine()!;

                Console.Write($"Annual Salary Name ({employee.AnnualSalary}): ");
                annualSalary = Console.ReadLine()!;

                Console.Write($"Gender Name ({employee.Gender}): ");
                gender = Console.ReadLine()!;

                Console.Write($"Manager Name ({employee.IsManager}): ");
                isManager = Console.ReadLine()!;

                _employees.Update(employee, 
                    String.IsNullOrWhiteSpace(firstName)? employee.FirstName : firstName,
                    String.IsNullOrWhiteSpace(lastName)? employee.LastName : lastName,
                    String.IsNullOrWhiteSpace(annualSalary)? employee.AnnualSalary : Decimal.Parse(annualSalary, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture),
                    String.IsNullOrWhiteSpace(gender)? employee.Gender : Convert.ToChar(gender),
                    String.IsNullOrWhiteSpace(isManager)? employee.IsManager : Convert.ToBoolean(isManager)
                );

            } else {
                Console.WriteLine(EmployeeCommonOutputText.GetEmployeeNotFoundMessage(id));
                Console.ReadKey();
            }

        }
    }
}
