using Task_Management_System.Data;
using Task_Management_System.Services;
using Task_Management_System.Utilities;
using TaskModel = Task_Management_System.Models.Task; // Alias to explicitly use the correct Task type

var taskService = new TaskService();
var filterService = new FilterService();
List<TaskModel> tasks = DataStorage.LoadTasks();

while (true)
{
    Console.Clear();
    Console.WriteLine("Task Management System");
    Console.WriteLine("1. Display Tasks");
    Console.WriteLine("2. Add Task");
    Console.WriteLine("3. Sort Tasks");
    Console.WriteLine("4. Filter Tasks");
    Console.WriteLine("5. Exit");

    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                taskService.DisplayTasks(tasks);
                break;
            case "2":
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter Description: ");
                string description = Console.ReadLine();
                Console.Write("Enter Due Date (YYYY-MM-DD): ");
                DateTime dueDate = InputValidator.ValidateDateInput(Console.ReadLine());
                Console.Write("Enter Status (Pending, In Progress, Completed): ");
                string status = InputValidator.ValidateStatusInput(Console.ReadLine());

                int taskId = tasks.Count > 0 ? tasks[^1].TaskID + 1 : 1;
                tasks.Add(new TaskModel
                {
                    TaskID = taskId,
                    Title = title,
                    Description = description,
                    DueDate = dueDate,
                    Status = status
                });
                DataStorage.SaveTasks(tasks);
                Console.WriteLine("Task added successfully.");
                break;
            case "3":
                Console.Write("Enter sorting criterion (Title, DueDate, Status): ");
                string criterion = Console.ReadLine();
                Console.Write("Enter sort order (Ascending, Descending): ");
                bool ascending = Console.ReadLine().Equals("Ascending", StringComparison.OrdinalIgnoreCase);
                tasks = taskService.SortTasks(tasks, criterion, ascending);
                taskService.DisplayTasks(tasks);
                break;
            case "4":
                Console.Write("Do you want to filter by date range? (yes/no): ");
                bool filterByRange = Console.ReadLine()?.Equals("yes", StringComparison.OrdinalIgnoreCase) ?? false;

                if (filterByRange)
                {
                    Console.Write("Enter the start date (YYYY-MM-DD): ");
                    DateTime startDate = InputValidator.ValidateDateInput(Console.ReadLine());

                    Console.Write("Enter the end date (YYYY-MM-DD): ");
                    DateTime endDate = InputValidator.ValidateDateInput(Console.ReadLine());

                    var filteredTasks = filterService.FilterByDateRange(tasks, startDate, endDate);
                    taskService.DisplayTasks(filteredTasks);
                }
                else
                {
                    Console.Write("Do you want to filter by Status? (yes/no): ");
                    bool filterByStatus = Console.ReadLine()?.Equals("yes", StringComparison.OrdinalIgnoreCase) ?? false;

                    string filterStatus = null;
                    if (filterByStatus)
                    {
                        Console.Write("Enter status (Pending, In Progress, Completed): ");
                        filterStatus = InputValidator.ValidateStatusInput(Console.ReadLine());
                    }

                    // Ask if the user wants to filter by a specific date condition (On, Before, After)
                    Console.Write("Do you want to filter by a specific date condition (On, Before, After)? (yes/no): ");
                    bool filterByDateCondition = Console.ReadLine()?.Equals("yes", StringComparison.OrdinalIgnoreCase) ?? false;

                    if (filterByDateCondition)
                    {
                        Console.Write("Enter the date (YYYY-MM-DD): ");
                        DateTime date = InputValidator.ValidateDateInput(Console.ReadLine());

                        Console.Write("Enter the condition (On, Before, After): ");
                        string condition = Console.ReadLine()?.ToLower();

                        // Apply the date condition filter
                        var filteredTasks = filterService.FilterByDueDate(tasks, date, condition);

                        // Apply status filter if specified
                        if (!string.IsNullOrEmpty(filterStatus))
                        {
                            filteredTasks = filterService.FilterByStatus(filteredTasks, filterStatus);
                        }

                        taskService.DisplayTasks(filteredTasks);
                    }
                    else
                    {
                        // Apply filtering by status and return the filtered list
                        var filteredTasks = filterService.FilterByMultipleCriteria(tasks, null, null, filterStatus);
                        taskService.DisplayTasks(filteredTasks);
                    }
                }
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
