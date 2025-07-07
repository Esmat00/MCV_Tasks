


using System;
using System.Collections.Generic;

public class InMemoryTaskStorage : ITaskStorage
{
    private List<string> tasks = new List<string>();

    public void LoadTasks()
    {
      
    }

    public void SaveTasks()
    {
        
    }

    public void AddTask(string task)
    {
        if (string.IsNullOrWhiteSpace(task))
            throw new ArgumentException("Task cannot be empty.");

        if (tasks.Exists(t => t.Equals(task, StringComparison.OrdinalIgnoreCase)))
            throw new ArgumentException("Task already exists.");

        tasks.Add(task);
    }

    public void RemoveTask(int index)
    {
        if (index < 0 || index >= tasks.Count)
            throw new ArgumentOutOfRangeException("Invalid task index.");

        tasks.RemoveAt(index);
    }

    public void EditTask(int index, string newTask)
    {
        if (string.IsNullOrWhiteSpace(newTask))
            throw new ArgumentException("Task cannot be empty.");
         
        if (tasks.Exists(t => t.Equals(newTask, StringComparison.OrdinalIgnoreCase)))
            throw new ArgumentException("Task already exists.");

        tasks[index] = newTask;
    }

    public List<string> GetTasks()
    {
        return new List<string>(tasks);
    }
}
