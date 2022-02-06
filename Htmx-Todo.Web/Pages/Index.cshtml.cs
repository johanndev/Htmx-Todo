using Htmx_Todo.TodoService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Htmx_Todo.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> logger;
    private readonly TodoService.TodoService todoService;

    public IEnumerable<TodoItem> OpenItems => todoService.OpenItems;
    public IEnumerable<TodoItem> DoneItems => todoService.DoneItems;

    public IndexModel(ILogger<IndexModel> logger, TodoService.TodoService todoService)
    {
        this.logger = logger;
        this.todoService = todoService;
    }

    public void OnGet()
    {
    }
    
    public void OnPostAdd(string newTodo)
    {
        todoService.Add(new(newTodo));
    }      
    public void OnPostMarkAsDone(TodoItem todoItem)
    {
        todoService.MarkAsDone(todoItem);
    }    
    public void OnPostRestore(TodoItem todoItem)
    {
        todoService.Restore(todoItem);
    }    
    public void OnPostDelete(TodoItem todoItem)
    {
        todoService.Delete(todoItem);
    }
}