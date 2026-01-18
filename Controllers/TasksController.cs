using Microsoft.AspNetCore.Mvc;
using TaskFlowREST.DTOs;
using TaskFlowREST.Models;
using TaskFlowREST.Services;

namespace TaskFlowREST.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private static int _nextId = 1;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<List<TaskItem>> GetAll()
    {
        var tasks = _taskService.GetAll();
        return Ok(tasks);
    }

    [HttpPost]
    public ActionResult<TaskItem> Create(CreateTaskDto dto)
    {
        var task = _taskService.Create(dto.Title);

        return CreatedAtAction(
            nameof(GetAll), new { id = task.Id }, task);
    }
}