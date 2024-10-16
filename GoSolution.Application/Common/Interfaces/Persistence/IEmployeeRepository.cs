using GoSolution.Domain.Entities;

namespace GoSolution.Application.Common.Interfaces.Persistence;

public interface IEmployeeRepository
{
    Employee? GetUserById(Guid id);
    Employee? GetUserByUsername(string username);
    void Add(Employee employee);
}