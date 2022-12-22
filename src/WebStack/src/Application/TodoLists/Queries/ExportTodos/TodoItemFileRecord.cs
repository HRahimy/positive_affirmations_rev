using WebStack.Application.Common.Mappings;
using WebStack.Domain.Entities;

namespace WebStack.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
