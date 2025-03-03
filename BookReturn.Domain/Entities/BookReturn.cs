using BookReturn.Domain.Enums;

namespace BookReturn.Domain.Entities;

public class BookReturn
{
    public Guid LoanId { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }
}
