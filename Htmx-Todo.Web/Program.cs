using Htmx_Todo.TodoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

var todoService = app.Services.GetRequiredService<TodoService>();
todoService.AddRange(new []
{
    new TodoItem("1"),
    new TodoItem("2"),
    new TodoItem("3"),
    new TodoItem("4"),
    new TodoItem("5"),
});

app.Run();