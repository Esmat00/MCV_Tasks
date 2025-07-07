
namespace To_Do_List_OOP
{
    internal interface ITaskStorage
    {
    }
}


public interface ITaskStorage
{
    void LoadTasks();
    void SaveTasks();
    void AddTask(string task);
    void RemoveTask(int index);
    void EditTask(int index, string newTask);
    List<string> GetTasks();
}
