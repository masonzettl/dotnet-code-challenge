using CodeChallenge.Models;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public ReportingSturcture GetByEmployeeId(string id)
        {
            // If the string is not empty or null, attempt to get the employee from the ID
            if (!string.IsNullOrEmpty(id))
            {
                Employee employee = _employeeService.GetById(id);

                // If an employee with the ID was not found, return null
                if (employee == null) return null;

                // Otherwise, return the reporting structure of the employee
                return new ReportingSturcture()
                {
                    Employee = employee
                };
            }

            return null;
        }
    }
}
