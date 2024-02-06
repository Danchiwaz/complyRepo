using API.Enums;

namespace API.Models;

public class  Item
{
    public int TaskID { get; set; }
    public long? TaskIDFactorial { get; set; }
    public Category Category { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
} 

// ItemService