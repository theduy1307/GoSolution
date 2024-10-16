using GoSolution.Domain.Entities;

namespace GoSolution.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Employee employee);
}