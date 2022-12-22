using WebStack.Application.TodoLists.Queries.ExportTodos;

namespace WebStack.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
