using TodoPackage;
using Fun;

class Program
{
    static void Main()
    {
        TodoList todoList = new TodoList();
        todoList.CowsayAdded += (string content) => CowSay.Call(content);

        while (true)
        {
            Console.Write("Enter a todo: ");
            string? todo = Console.ReadLine();

            if (string.IsNullOrEmpty(todo))
            {
                Console.WriteLine("Please enter a todo.");
            }
            else if (todo == "--all")
            {
                List<Todo> list = todoList.GetAll();

                foreach (var l in list)
                {
                    Console.WriteLine($"{l.Id} - {l.Content} - {(l.IsDone ? "D" : "ND")}");
                }
            }
            else if (todo == "--find")
            {
                int? id = GetIdOnConsole();
                if (id == null) continue;

                Todo? item = todoList.FindById(id.Value);
                if (item == null)
                {
                    Console.WriteLine("Item not found.");
                    continue;
                }

                Console.WriteLine(item.Content);
            }
            else if (todo == "--edit")
            {
                int? id = GetIdOnConsole();
                if (id == null) continue;

                string content;
                while (true)
                {
                    Console.Write("Enter a new value: ");
                    string? newContent = Console.ReadLine();

                    if (string.IsNullOrEmpty(newContent))
                    {
                        Console.WriteLine("Please enter a value.");
                        continue;
                    }

                    content = newContent;
                    break;
                }

                todoList.Edit(id.Value, content);
            }
            else if (todo == "--delete")
            {
                int? id = GetIdOnConsole();
                if (!id.HasValue) continue;

                todoList.Delete(id.Value);

            }
            else if (todo == "--toggle")
            {
                int? id = GetIdOnConsole();
                if (!id.HasValue) continue;

                todoList.Toggle(id.Value);
            }
            else
            {
                todoList.Add(todo);
            }
        }
    }

    static int? GetIdOnConsole()
    {
        while (true)
        {
            Console.Write("Enter an ID: ");
            string? idToDelete = Console.ReadLine();

            if (string.IsNullOrEmpty(idToDelete))
            {
                Console.WriteLine("Please enter an ID.");
                continue;
            }
            else if (idToDelete == "--exit")
            {
                break;
            }

            int id;
            bool isNum = int.TryParse(idToDelete, out id);
            if (!isNum)
            {
                Console.WriteLine("Please enter a number.");
                continue;
            }

            return id;
        }

        return null;
    }
}
