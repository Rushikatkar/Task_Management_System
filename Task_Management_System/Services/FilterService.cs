using TaskModel = Task_Management_System.Models.Task;

namespace Task_Management_System.Services
{
    public class FilterService
    {
        public List<TaskModel> FilterByDueDate(List<TaskModel> tasks, DateTime date, string condition)
        {
            return condition.ToLower() switch
            {
                "on" => tasks.Where(t => t.DueDate.Date == date.Date).ToList(),
                "before" => tasks.Where(t => t.DueDate.Date < date.Date).ToList(),
                "after" => tasks.Where(t => t.DueDate.Date > date.Date).ToList(),
                _ => throw new ArgumentException("Invalid date filter condition.")
            };
        }

        public List<TaskModel> FilterByStatus(List<TaskModel> tasks, string status)
        {
            return tasks.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<TaskModel> FilterByMultipleCriteria(List<TaskModel> tasks, DateTime? dueDate = null, string condition = null, string status = null)
        {
            var filteredTasks = tasks.AsEnumerable();

            if (dueDate.HasValue && !string.IsNullOrEmpty(condition))
            {
                filteredTasks = condition.ToLower() switch
                {
                    "on" => filteredTasks.Where(t => t.DueDate.Date == dueDate.Value.Date),
                    "before" => filteredTasks.Where(t => t.DueDate.Date < dueDate.Value.Date),
                    "after" => filteredTasks.Where(t => t.DueDate.Date > dueDate.Value.Date),
                    _ => throw new ArgumentException("Invalid date filter condition.")
                };
            }

            if (!string.IsNullOrEmpty(status))
            {
                filteredTasks = filteredTasks.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            return filteredTasks.ToList();
        }

        public List<TaskModel> FilterByDateRange(List<TaskModel> tasks, DateTime startDate, DateTime endDate)
        {
            return tasks.Where(t => t.DueDate.Date >= startDate.Date && t.DueDate.Date <= endDate.Date).ToList();
        }


    }
}
