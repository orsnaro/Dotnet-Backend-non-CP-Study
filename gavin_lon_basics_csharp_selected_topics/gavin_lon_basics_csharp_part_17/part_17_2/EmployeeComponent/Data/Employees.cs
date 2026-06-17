using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeComponent.Data {
    public class Employees {
        ArrayList _employeeList = null!;

        public Employees() {
                _employeeList = new ArrayList();
                SeedData();
        }

        private void SeedData() {
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Devin", "Smith", 60000, 'm', false));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Andrew", "Jones", 40000, 'm', false));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Brenda", "Anderson", 100000, 'f', true));
            this.Add(EmployeeObjectFactory.CreateNewEmployeeObject("Angela", "Roberts", 30000, 'f', false));
        }


        public Employee this[int index] {//an indexer to be traversable and enumerable using for loop
            get {
                return (Employee)_employeeList[index];
            }
        }

        public IEnumerator GetEnumerator() {//implement enumerator for the class so we can traverse using foreach loop
            return _employeeList.GetEnumerator();
        }
            

           //crud
        public void Add(Employee employee) { 
            _employeeList.Add(employee);
        }


        //crud
        public void Update(Employee employee,string firstname, string lastname, decimal annualSalary, char gender, bool isManager) { 
            employee.FirstName = firstname;
            employee.LastName = lastname;
            employee.AnnualSalary = annualSalary;
            employee.Gender = gender;
            employee.IsManager = isManager;
        }


        //crud
        public void Delete(int index) {
            _employeeList.RemoveAt(index);
        }

        public int Find(int id) {
            int index = 0;


            foreach (Employee emp in _employeeList) { 
                if(emp.Id == id) return index;
                index++;
            }

            return -1;
        }


        public int Count() {
            return _employeeList.Count;
        }


    }
}
