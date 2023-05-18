using System;
using System.Collections.Generic;

public class Task
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string name)
    {
        Name = name;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
}

public class TodoList
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(string taskName)
    {
        Task newTask = new Task(taskName);
        tasks.Add(newTask);
    }

    public void MarkTaskAsCompleted(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            Task task = tasks[index];
            task.IsCompleted = true;
        }
    }

    public void DeleteTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
    }

    public void PrintTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        TodoList todoList = new TodoList();

        while (true)
        {
            Console.WriteLine("---- Todo List ----");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Task as Completed");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Print Tasks");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-------------------");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task name: ");
                    string taskName = Console.ReadLine();
                    todoList.AddTask(taskName);
                    Console.WriteLine("Task added successfully!");
                    break;

                case "2":
                    Console.Write("Enter task index: ");
                    if (int.TryParse(Console.ReadLine(), out int completeIndex))
                    {
                        todoList.MarkTaskAsCompleted(completeIndex - 1);
                        Console.WriteLine("Task marked as completed!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid index!");
                    }
                    break;

                case "3":
                    Console.Write("Enter task index: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                    {
                        todoList.DeleteTask(deleteIndex - 1);
                        Console.WriteLine("Task deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid index!");
                    }
                    break;

                case "4":
                    Console.WriteLine("Tasks:");
                    todoList.PrintTasks();
                    break;

                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine();
        }
    }
}
