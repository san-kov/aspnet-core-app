using TaskFlowREST.Models;

namespace TaskFlowREST.Services;

public interface ITaskService
{
    List<TaskItem> GetAll();
    TaskItem Create(string title);
}