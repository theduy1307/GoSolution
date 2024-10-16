namespace GoSolution.Domain.Entities;

public class PoliticalQualification
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Employee> Employees = new List<Employee>();
}