using System.Collections.ObjectModel;
using Htmx_Todo.Web.Pages;

namespace Htmx_Todo.TodoService;

public enum TodoStatus
{
    Open,
    Done
}

public record TodoItem(string Name)
{
    public int Id { get; init; }
    public TodoStatus Status { get; private set; }

    public void MarkAsDone()
    {
        Status = TodoStatus.Done;
    }

    public void Restore()
    {
        Status = TodoStatus.Open;
    }
}

public class TodoService
{
    private int runningId;
    private List<TodoItem> todoItems = new();

    public void Add(TodoItem todoItem)
    {
        todoItems.Add(todoItem with {Id = runningId++});
    }

    public IReadOnlyList<TodoItem> Items => todoItems.AsReadOnly();

    public void AddRange(IEnumerable<TodoItem> range)
    {
        foreach (var todoItem in range)
        {
            Add(todoItem);
        }
    }

    public void MarkAsDone(TodoItem todoItem)
    {
        var existingItem = todoItems.Single(t => t.Id == todoItem.Id);
        existingItem.MarkAsDone();
    }

    public void Restore(TodoItem todoItem)
    {
        var existingItem = todoItems.Single(t => t.Id == todoItem.Id);
        existingItem.Restore();
    }

    public void Delete(TodoItem todoItem)
    {
        var existingItem = todoItems.Single(t => t.Id == todoItem.Id);
        todoItems.Remove(existingItem);
    }
}