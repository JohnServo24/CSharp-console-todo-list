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
    List<Todo> list = new List<Todo>();
    int nextId = 0;

    public void Add(string todo)
    {
        list.Add(new Todo(nextId++, todo));
    }

    public void Delete(int id)
    {
        int idx = list.FindIndex(l => l.Id == id);
        if (idx == -1)
        {
            Console.WriteLine("Out of bounds.");
            return;
        }

        list.RemoveAt(idx);
    }

    public void Edit(int id, string newContent)
    {
        int idx = list.FindIndex(l => l.Id == id);
        if (idx == -1)
        {
            Console.WriteLine("Out of bounds.");
            return;
        }

        list[idx].Content = newContent;
    }

    public Todo? FindById(int id) => list.Find(l => l.Id == id);

    public List<Todo> GetAll() => list;
}
