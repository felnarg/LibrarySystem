using DomainProject.Enums;

namespace DomainProject.Entities;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Cellphone { get; set; }
    public string? City { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.Now;
    public UserStatus Status { get; set; } = UserStatus.Enabled;
    public ICollection<Loan>? Loan { get; set; }
}