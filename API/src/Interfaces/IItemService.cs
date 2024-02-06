using API.Models;

namespace API.Interfaces;
public interface IItemService
{
    List<Item> GetAllTasks();
    Item AddTask(Item newTask);
    long CalculateFactorial(int TaskID);
}
