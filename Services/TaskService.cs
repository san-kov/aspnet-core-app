using TaskFlowREST.Models;

namespace TaskFlowREST.Services;

public class TaskService : ITaskService
{
    private static readonly List<TaskItem> _tasks = new();
    private static int _nextId = 1;

    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public TaskItem Create(string title)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false,
        };
        
        _tasks.Add(task);
        return task;
    }
}