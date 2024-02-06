using API.Enums;

namespace API.Models;

public static class DummyData
{
    public static List<Item> Seed()
    {
        return new List<Item>
        {
            new Item { TaskID = 1, Category = Category.Academics, Description = "Revise for my upcoming exams", DueDate = DateTime.Now.AddDays(30), Priority = Priority.High, Status = Status.NotStarted },
            new Item { TaskID = 2, Category = Category.health, Description = "Check my BMI with an expert", DueDate = DateTime.Now.AddDays(10), Priority = Priority.Medium, Status = Status.InProgress },
            new Item { TaskID = 3, Category = Category.Technology, Description = "Research more on AI", DueDate = DateTime.Now.AddDays(20), Priority = Priority.Low, Status = Status.NotStarted },
            new Item { TaskID = 4, Category = Category.Agriculture, Description = "Plant some maize for the cattle", DueDate = DateTime.Now.AddDays(15), Priority = Priority.High, Status = Status.Completed },
            new Item { TaskID = 5, Category = Category.Academics, Description = "Attende my classes", DueDate = DateTime.Now.AddDays(5), Priority = Priority.High, Status = Status.InProgress },
            new Item { TaskID = 6, Category = Category.health, Description = "Research more on how to eat healthy", DueDate = DateTime.Now.AddDays(40), Priority = Priority.Medium, Status = Status.NotStarted },
        };
    }
}

