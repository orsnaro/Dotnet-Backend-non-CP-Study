using EmployeeComponent;
using EmployeeComponent.Data;
using EmployeeComponent.Views;

namespace part_17_2_crud_employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool endApplication = false;

            Employees employees = new Employees();

            EmployeeRecordsView employeeRecordsView = EmployeeObjectFactory.EmployeeRecordsViewObject(employees);



            while (!endApplication) {
                Console.Clear();

                Console.WriteLine(EmployeeCommonOutputText.GetApplicationHeading());

                employeeRecordsView.RunRecordsView();

                Console.WriteLine( );
                Console.WriteLine( );

                Console.WriteLine(EmployeeCommonOutputText.GetInstructions());

                ConsoleKey instructionKey = Console.ReadKey().Key;

                if (instructionKey == ConsoleKey.C) {
                    EmployeeCreateView employeeCreateView = EmployeeObjectFactory.EmployeeCreateViewObject(employees);
                    employeeCreateView.RunCreateView();
                } else if (instructionKey == ConsoleKey.R) {
                    EmployeeReadView employeeReadView = EmployeeObjectFactory.EmployeeReadViewObject(employees);
                    employeeReadView.RunReadView();
                } else if (instructionKey == ConsoleKey.U) {
                    EmployeeUpdateView employeeUpdateView = EmployeeObjectFactory.EmployeeUpdateViewObject(employees);
                    employeeUpdateView.RunUpdateView();
                } else if (instructionKey == ConsoleKey.D) {
                    EmployeeDeleteView employeeDeleteView = EmployeeObjectFactory.EmployeeDeleteViewObject(employees);
                    employeeDeleteView.RunDeleteView();
                } else {
                    endApplication = true;
                }
            }

            Console.ReadKey();
        }
    }
}
