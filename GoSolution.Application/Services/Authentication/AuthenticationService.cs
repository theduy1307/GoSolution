using GoSolution.Application.Common.Interfaces.Authentication;
using GoSolution.Application.Common.Interfaces.Persistence;
using GoSolution.Domain.Entities;

namespace GoSolution.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IEmployeeRepository _employeeRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IEmployeeRepository employeeRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _employeeRepository = employeeRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string username, string password)
    {
        // 1. Validate the user doesn't exist
        if (_employeeRepository.GetUserByUsername(username) is not null)
        {
            throw new Exception("User with given email already exists");
        }
        // 2. Create user (generate unique Id) & persist to DB
        var employee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            Id = Guid.NewGuid(),
            Account = new Account()
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = password
            }
        };
        _employeeRepository.Add(employee);
        
        // Create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(employee);
        return new AuthenticationResult(employee, token);
    }

    public AuthenticationResult Login(string username, string password)
    {
        // 1. Validate the user exists
        if (_employeeRepository.GetUserByUsername(username) is not Employee employee)
        {
            throw new Exception("User with given email does not exist.");
        }
        // 2. Validate the password is correct
        if (employee.Account?.Password != password)
        {
            throw new Exception("Invalid password");
        }
        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(employee);
        return new AuthenticationResult(
            employee, 
            token);
    }
}