using TaskModel = Task_Management_System.Models.Task;

namespace Task_Management_System.Services
{
    public class TaskService
    {
        public void DisplayTasks(List<TaskModel> tasks)
        {
            if (tasks == null || !tasks.Any())
            {
                Console.WriteLine("No tasks to display.");
                return;
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("| {0,-5} | {1,-20} | {2,-30} | {3,-15} | {4,-12} |", "ID", "Title", "Description", "Due Date", "Status");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            foreach (var task in tasks)
            {
                Console.WriteLine("| {0,-5} | {1,-20} | {2,-30} | {3,-15:yyyy-MM-dd} | {4,-12} |",
                    task.TaskID, task.Title, task.Description, task.DueDate, task.Status);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }


        public List<TaskModel> SortTasks(List<TaskModel> tasks, string criterion, bool ascending)
        {
            return criterion.ToLower() switch
            {
                "title" => ascending
                    ? tasks.OrderBy(t => t.Title).ToList()
                    : tasks.OrderByDescending(t => t.Title).ToList(),
                "duedate" => ascending
                    ? tasks.OrderBy(t => t.DueDate).ToList()
                    : tasks.OrderByDescending(t => t.DueDate).ToList(),
                "status" => ascending
                    ? tasks.OrderBy(t => t.Status).ToList()
                    : tasks.OrderByDescending(t => t.Status).ToList(),
                _ => throw new ArgumentException("Invalid sorting criterion.")
            };
        }
    }
}
