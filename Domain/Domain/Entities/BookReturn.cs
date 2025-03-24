using Domain.Enums;

namespace Domain.Entities;

public class BookReturn
{
    public Guid LoanId { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public BookReturnStatus Status { get; set; }
}