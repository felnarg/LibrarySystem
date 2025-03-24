using Domain.Enums;

namespace User.Domain.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Cellphone { get; set; }
    public string? City { get; set; }
    public DateTime RegisterDate { get; set; }
    public UserStatus Status { get; set; }
}