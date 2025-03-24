using Shared.Domain.Enums;
using Shared.Domain.Interfaces;

namespace Book.Domain.Entities;

public class Book : IBook
{
    public Guid BookId { get; set; }
    public string? BookName { get; set; }
    public int Quantity { get; set; }
    public int QuantityAvailable { get; set; }
    public Category Category { get; set; }
    public string? Author { get; set; }
    public string? Editorial { get; set; }
    public ILoan? Loan { get; set; }
}
