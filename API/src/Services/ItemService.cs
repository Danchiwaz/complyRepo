using API.Models;
using API.Interfaces;

namespace API.Services;
public class ItemService : IItemService
{
    private static List<Item> Items = new List<Item>();

    public ItemService()
    {
        if (!Items.Any())
        {
            Items = DummyData.Seed();
        }
    }

    public List<Item> GetAllTasks()
    {
        return Items;
    }

    public Item AddTask(Item newTask)
    {
        newTask.TaskID = Items.Count + 1;
        Items.Add(newTask);
        return newTask;
    }

    public long CalculateFactorial(int n)
    {
        if (n == 0) return 1;
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
