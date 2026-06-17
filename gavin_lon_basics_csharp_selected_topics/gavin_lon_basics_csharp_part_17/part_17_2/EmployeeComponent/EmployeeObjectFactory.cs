using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeComponent.Data;
using EmployeeComponent.Views;

namespace EmployeeComponent {
    public static class EmployeeObjectFactory {
        //CRUD

        private static EmployeeCreateView? _employeeCreateView = null;
        private static EmployeeReadView? _employeeReadView = null;
        private static EmployeeUpdateView? _employeeUpdateView = null;
        private static EmployeeDeleteView? _employeeDeleteView = null;

        public static Employee CreateNewEmployeeObject(string firstname, string lastname, decimal annualSalary, char gender, bool isManager) {
            return new Employee {
                FirstName = firstname,
                LastName = lastname,
                AnnualSalary = annualSalary,
                Gender = gender,
                IsManager = isManager
            };
        }

        public static EmployeeRecordsView EmployeeRecordsViewObject(Employees employees) { 
            return new EmployeeRecordsView(employees);
        }

        public static EmployeeCreateView EmployeeCreateViewObject(Employees employees) {
            if(_employeeCreateView == null) {
                _employeeCreateView = new EmployeeCreateView(employees);
            }
            return new EmployeeCreateView(employees);
        } 

        public static EmployeeReadView EmployeeReadViewObject(Employees employees) {
            if(_employeeReadView == null) {
                _employeeReadView = new EmployeeReadView(employees);
            }
            return new EmployeeReadView(employees);
        } 

        public static EmployeeUpdateView EmployeeUpdateViewObject(Employees employees) {
            if(_employeeUpdateView == null) {
                _employeeUpdateView = new EmployeeUpdateView(employees);
            }
            return new EmployeeUpdateView(employees);
        } 

        public static EmployeeDeleteView EmployeeDeleteViewObject(Employees employees) {
            if(_employeeDeleteView == null) {
                _employeeDeleteView = new EmployeeDeleteView(employees);
            }
            return new EmployeeDeleteView(employees);
        } 
        
    }
}
