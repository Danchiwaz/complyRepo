using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class ItemContext: DbContext{
    public ItemContext(DbContextOptions<ItemContext> options): 
    base(options)
    {

    }
    public DbSet<Item> ItemServices { get; set; } = null!;
}