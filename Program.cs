namespace ToDoApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to the to do list program.");
      List<string> taskList = new List<string>();
      string option = "";

      while (option != "e")
      {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("Enter 1 to add a task to the list.");
        Console.WriteLine("Enter 2 to remove a task from the list.");
        Console.WriteLine("Enter 3 to view the list.");
        Console.WriteLine("Enter e to exit the program.");

        option = Console.ReadLine() ?? ""; // Holds the user's choice. If ReadLine() is null, default to empty string.

        if (option == "1")
        {
          Console.WriteLine("Please enter the name of the task to add to the list.");
          string? taskInput = Console.ReadLine(); // Read as nullable (string?).

          if (!string.IsNullOrWhiteSpace(taskInput)) // Check for null, empty, or whitespace.
          {
            taskList.Add(taskInput); // taskInput is guaranteed non-null here.
            Console.WriteLine("Task added to the list.");
          }
          else
          {
            Console.WriteLine("Task cannot be empty. Please enter a valid task name.");
          }
        }
        else if (option == "2")
        {
          // Display tasks before asking for removal.
          if (taskList.Count == 0)
          {
            Console.WriteLine("No tasks to remove.");
          }
          else
          {
            Console.WriteLine("Current tasks:");
            for (int i = 0; i < taskList.Count; i++)
            {
              Console.WriteLine($"{i + 1}: {taskList[i]}");
            }

            Console.WriteLine("Please enter the number of the task to remove from the list.");
            string? taskNumberInput = Console.ReadLine();

            if (int.TryParse(taskNumberInput, out int taskNumber)) // out = 0 if parse is false.
            {
              // Validate the entered number against the list's bounds.
              if (taskNumber > 0 && taskNumber <= taskList.Count)
              {
                taskList.RemoveAt(taskNumber - 1); // - 1 because list is 0-indexed.
                Console.WriteLine("Task removed from the list.");
              }
              else
              {
                Console.WriteLine("Invalid task number. Please enter a number shown in the list.");
              }
            }
            else
            {
              Console.WriteLine("Invalid input. Please enter a number.");
            }
          }
        }
        else if (option == "3")
        {
          Console.WriteLine("Current tasks in the list:");

          if (taskList.Count == 0)
          {
            Console.WriteLine("No current tasks.");
          }

          for (int i = 0; i < taskList.Count; i++)
          {
            Console.WriteLine(taskList[i]);
          }
        }
        else if (option == "e")
        {
          Console.WriteLine("Exiting program.");
        }
        else
        {
          Console.WriteLine("Invalid option, please try again.");
        }
      }

      Console.WriteLine("Thank you for using our program."); 
    }
  }
}