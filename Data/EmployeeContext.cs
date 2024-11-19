using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeAPI.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } 
    }
}
