using GoSolution.Domain.Entities;

namespace GoSolution.Application.Services.Authentication;

public record AuthenticationResult
(
    Employee Employee,
    string Token
);