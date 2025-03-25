using DomainProject.Enums;

namespace DomainProject.Entities;

public class Loan
{
    public Guid LoanId { get; set; }
    public Guid UserId { get; set; } 
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public LoanStatus Status { get; set; }
}
