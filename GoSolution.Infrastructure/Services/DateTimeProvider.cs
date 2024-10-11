using GoSolution.Application.Common.Interfaces.Services;

namespace GoSolution.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}