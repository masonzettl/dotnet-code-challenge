using CodeChallenge.Models;

namespace CodeChallenge.Services
{
    public interface IReportingStructureService
    {
        ReportingSturcture GetByEmployeeId(string id);
    }
}
