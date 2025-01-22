using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Models
{
    public class ReportingSturcture
    {
        // Properties

        // The employee associated with the reporting structure.
        [Required]
        public Employee Employee { get; set; }
        // The total number of reports under the employee.
        public int NumberOfReports
        {
            get
            {
                // If the employee has no direct reports, return early with 0
                if (Employee.DirectReports == null) return 0;

                // Initialize a number of reports with the amount of direct reports the employee has.
                int numberOfReports = Employee.DirectReports.Count;

                // Loop through all direct reports and add up their direct reports, running this property recursively.
                foreach(Employee directReport in Employee.DirectReports)
                {
                    // Get the reporting structure of the direct report and get their number of reports.
                    ReportingSturcture reportingSturcture = new ReportingSturcture()
                    {
                        Employee = directReport
                    };

                    // Add their number of reports to the sum.
                    numberOfReports += reportingSturcture.NumberOfReports;
                }

                // Return the sum of total reports.
                return numberOfReports;
            }
        }
    }
}
