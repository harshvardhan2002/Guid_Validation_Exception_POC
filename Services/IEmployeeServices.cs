using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public interface IEmployeeServices
    {
        public List<Employee> GetEmployees();
        public Employee GetById(Guid id);
        public Guid AddEmployee(Employee employee);
    }
}
