namespace GoSolution.Domain.Entities;

public class PlaceOfIssueOfPassport
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}