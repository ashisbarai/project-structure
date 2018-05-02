using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.Core.Entities;

namespace Architecture.Core.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
    }

    public static class EmployeeDtoExtension
    {
        public static IEnumerable<EmployeeDto> ToEmployeeDtos(this IEnumerable<Employee> employees)
        {
            return employees.Select(ToEmployeeDto);
        }
        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address,
                CreatedOn = employee.CreatedOn,
                ManagerId = employee.ManagerId,
                Manager = employee.Manager
            };
        }
        public static Employee ToEmployee(this EmployeeDto employee)
        {
            return new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address,
                CreatedOn = employee.CreatedOn,
                ManagerId = employee.ManagerId
            };
        }
    }
}
