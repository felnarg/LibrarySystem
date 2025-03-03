using Book.Domain.Enums;

namespace Book.Domain.Entities;

public class Book
{
    public Guid BookId { get; set; }
    public string? BookName { get; set; }
    public int Quantity { get; set; }
    public int QuantityAvailable { get; set; }
    public Category Category { get; set; }
    public string? Author { get; set; }
    public string? Editorial { get; set; }
}
