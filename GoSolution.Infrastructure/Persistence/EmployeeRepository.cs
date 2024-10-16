using GoSolution.Application.Common.Interfaces.Persistence;
using GoSolution.Domain.Entities;

namespace GoSolution.Infrastructure.Persistence;

public class EmployeeRepository : IEmployeeRepository
{
    private static readonly List<Employee> _employees = new();
    public Employee? GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Employee? GetUserByUsername(string username)
    {
        return _employees.SingleOrDefault(u => u.Account?.Username == username);
    }

    public void Add(Employee employee)
    {
        _employees.Add(employee);
    }
}