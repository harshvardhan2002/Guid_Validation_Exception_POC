using EmployeeAPI.Exceptions;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services
{
    public class EmployeeServices:IEmployeeServices
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeServices(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        public List<Employee> GetEmployees()
        {
            return _repository.GetAll().ToList();
        }

        public Employee GetById(Guid id)
        {
            var employee = _repository.Get(id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException($"No such Employee exists.");
            }
            return employee;
        }

        public Guid AddEmployee(Employee employee)
        {
            _repository.Add(employee);
            return employee.Id;
        }
    }
}
