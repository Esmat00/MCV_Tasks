using System;
using System.Collections;
using System.IO;

class Program1
{
    static string filePath = "tasks.txt";
    static ArrayList toDoList = new ArrayList();

    static void Main(string[] args)
    {
        
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        else
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    toDoList.Add(line.Trim());
            }
        }

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

            if (choice == "1")
            {
                AddTask();
            }
            else if (choice == "2")
            {
                RemoveTask();
            }
            else if (choice == "3")
            {
                ShowTasks();
            }
            else if (choice == "4")
            {
                EditTask();
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Exiting Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }

    static void SaveTasksToFile()
    {
        File.WriteAllLines(filePath, (string[])toDoList.ToArray(typeof(string)));
    }

    static void AddTask()
    {
        Console.Write("Enter the task to add: ");
        string taskToAdd = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(taskToAdd))
        {
            Console.WriteLine("Task cannot be empty.");
            return;
        }

        foreach (string task in toDoList)
        {
            if (task.Equals(taskToAdd, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Task already exists.");
                return;
            }
        }

        toDoList.Add(taskToAdd);
        SaveTasksToFile();
        Console.WriteLine("Task added.");
    }

    static void RemoveTask()
    {
        if (toDoList.Count == 0)
        {
            Console.WriteLine("No tasks to remove.");
            return;
        }

        ShowTasks();

        Console.Write("Enter the task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int indexToRemove) &&
            indexToRemove >= 1 && indexToRemove <= toDoList.Count)
        {
            string removedTask = (string)toDoList[indexToRemove - 1];
            toDoList.RemoveAt(indexToRemove - 1);
            SaveTasksToFile();
            Console.WriteLine($"Task removed: {removedTask}");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void ShowTasks()
    {
        Console.WriteLine("\nYour Tasks:");
        if (toDoList.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {toDoList[i]}");
            }
        }
    }

    static void EditTask()
    {
        if (toDoList.Count == 0)
        {
            Console.WriteLine("No tasks to edit.");
            return;
        }

        ShowTasks();

        Console.Write("Enter the task number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int indexToEdit) &&
            indexToEdit >= 1 && indexToEdit <= toDoList.Count)
        {
            Console.Write("Enter the new text for the task: ");
            string newTask = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(newTask))
            {
                Console.WriteLine("New task cannot be empty.");
                return;
            }

            foreach (string task in toDoList)
            {
                if (task.Equals(newTask, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Task already exists.");
                    return;
                }
            }

            toDoList[indexToEdit - 1] = newTask;
            SaveTasksToFile();
            Console.WriteLine("Task updated.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}
