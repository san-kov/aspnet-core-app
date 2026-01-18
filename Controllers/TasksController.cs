using Microsoft.AspNetCore.Mvc;
using TaskFlowREST.DTOs;
using TaskFlowREST.Models;

namespace TaskFlowREST.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> _tasks = new();
    private static int _nextId = 1;

    [HttpGet]
    public ActionResult<List<TaskItem>> GetAll()
    {
        return Ok(_tasks);
    }

    [HttpPost]
    public ActionResult<TaskItem> Create(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = dto.Title,
            IsCompleted = false
        };
        
        _tasks.Add(task);

        return CreatedAtAction(
            nameof(GetAll), new { id = task.Id }, task);
    }
}