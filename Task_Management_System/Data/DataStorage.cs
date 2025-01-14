using TaskModel = Task_Management_System.Models.Task;
using System.Text.Json;

namespace Task_Management_System.Data
{
    public static class DataStorage
    {
        private const string FilePath = "tasks.json";

        public static List<TaskModel> LoadTasks()
        {
            if (!File.Exists(FilePath)) return new List<TaskModel>();

            string jsonData = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<TaskModel>>(jsonData) ?? new List<TaskModel>();
        }

        public static void SaveTasks(List<TaskModel> tasks)
        {
            string jsonData = JsonSerializer.Serialize(tasks);
            File.WriteAllText(FilePath, jsonData);
        }
    }
}
