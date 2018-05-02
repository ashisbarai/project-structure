using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;
using Architecture.Core.Interfaces;

namespace Architecture.Core.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IRepository<Employee> employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {            
            return await _employeeRepository.GetAllAsync();
        }

        public async Task CreateAsync(Employee employee)
        {
            _employeeRepository.Add(employee);
            await _unitOfWork.CommitAsync();
        }
    }
}