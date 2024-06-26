namespace TodoPackage;

public class Todo
{
    public int Id { get; private set; }
    public string Content { get; set; }
    public bool IsDone { get; set; }

    public Todo(int id, string content, bool isDone = false)
    {
        Id = id;
        Content = content;
        IsDone = isDone;
    }
}

public class TodoList
{
    public event Action<string>? CowsayAdded;

    List<Todo> list = new List<Todo>();
    int nextId = 0;

    public void Add(string todo)
    {
        list.Add(new Todo(nextId++, todo));

        if (todo.StartsWith("cowsay:"))
        {
            CowsayAdded?.Invoke(todo);
        }
    }

    public void Delete(int id)
    {
        int idx = list.FindIndex(t => t.Id == id);
        if (idx == -1)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        list.RemoveAt(idx);
    }

    public void Edit(int id, string newContent)
    {
        var item = list.FirstOrDefault(t => t.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        item.Content = newContent;
    }

    public void Toggle(int id)
    {
        var item = list.FirstOrDefault(t => t.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        item.IsDone = !item.IsDone;
    }

    public Todo? FindById(int id) => list.FirstOrDefault(t => t.Id == id);

    public List<Todo> GetAll() => list;
}
