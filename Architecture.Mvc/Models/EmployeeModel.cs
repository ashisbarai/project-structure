using System;
using System.ComponentModel.DataAnnotations;
using Architecture.Core.Entities;

namespace Architecture.Web.Models
{
    public class EmployeeModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }
    }

    public static class EmployeeModelExtension
    {
        public static Employee ToEmployee(this EmployeeModel employeeModel)
        {
            return new Employee
            {
                Name = employeeModel.Name,
                Email = employeeModel.Email,
                Address = employeeModel.Address,
                ManagerId = employeeModel.ManagerId,
                CreatedOn = DateTimeOffset.UtcNow
            };
        }
    }
}