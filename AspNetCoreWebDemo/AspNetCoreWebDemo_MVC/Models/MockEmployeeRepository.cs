using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebDemo_MVC.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _EmployeeList;

        public MockEmployeeRepository()
        {
            _EmployeeList = new List<Employee>()
            {
                new Employee() { Id=1, Name="Mary", Department="HR",Email="mary@email.com"},
                new Employee() {Id=2, Name="John", Department="IT",Email="john@email.com"},
                new Employee() {Id=3, Name="Sam", Department="IT",Email="sam@email.com"}
            };
        }

        public Employee GetEmployee(int id)
        {
            return _EmployeeList.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployeeList()
        {
            return _EmployeeList;
        }
    }
}
