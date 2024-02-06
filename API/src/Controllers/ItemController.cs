using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Interfaces;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemServiceController: ControllerBase
{
    private readonly IItemService _ItemServiceService;

    public ItemServiceController(IItemService ItemServiceService)
    {
        _ItemServiceService = ItemServiceService;
    }


    [HttpGet("tasks")]
    public ActionResult<IEnumerable<Item>> GetTasks()
    {
        return Ok(_ItemServiceService.GetAllTasks());
    }

    [HttpPost("task")]
    public ActionResult<Item> AddTask(Item newTask)
    {
        try
        {
            if (newTask == null)
            {
                return BadRequest("Task is null");
            }

            var createdTask = _ItemServiceService.AddTask(newTask);
            return CreatedAtAction(nameof(GetTasks), new { id = createdTask.TaskID }, createdTask);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // This combines the results and sends them to frontend together instead of one by one.
    //TODO: Implement streaming to support displaying the results as each ItemService's data processing is completed.
    [HttpGet("tasks/factorial")]
    public IActionResult CalculateFactorials()
    {
        try{
            var tasks = _ItemServiceService.GetAllTasks();

            //This is not thread safe, improvements to make it thread safe in case of database calls
            Parallel.ForEach(tasks, task =>
            {
                task.TaskIDFactorial = _ItemServiceService.CalculateFactorial(task.TaskID);
            });

            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}