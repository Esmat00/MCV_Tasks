using System;
using System.Collections.Generic;
using To_Do_List_OOP;

class Program
{
    static ITaskStorage storage = new InMemoryTaskStorage();

    static void Main(string[] args)
    {
        storage.LoadTasks();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n  Welcome To-Do List  ");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. Show Tasks");
            Console.WriteLine("4. Edit Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

           
            
                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ShowTasks();
                        break;
                    case "4":
                        EditTask();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            
           
            {
              
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter the task to add: ");
        string task = Console.ReadLine();
        storage.AddTask(task);
        storage.SaveTasks();
        Console.WriteLine("Task added.");
    }

    static void RemoveTask()
    {
        var tasks = storage.GetTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to remove.");
            return;
        }

        ShowTasks();
        Console.Write("Enter the task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            storage.RemoveTask(index - 1);
            storage.SaveTasks();
            Console.WriteLine("Task removed.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void EditTask()
    {
        var tasks = storage.GetTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to edit.");
            return;
        }

        ShowTasks();
        Console.Write("Enter the task number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            Console.Write("Enter the new text: ");
            string newTask = Console.ReadLine();
            storage.EditTask(index - 1, newTask);
            storage.SaveTasks();
            Console.WriteLine("Task updated.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void ShowTasks()
    {
        var tasks = storage.GetTasks();
        Console.WriteLine("\nYour Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }
}

