# Task Management System

A console-based Task Management System built using C# to manage tasks with functionality such as adding tasks, sorting tasks, and filtering tasks based on various criteria like date range and status.

## Features
- **Display Tasks**: View all tasks with their details.
- **Add Task**: Add a new task by specifying title, description, due date, and status.
- **Sort Tasks**: Sort tasks based on title, due date, or status, in ascending or descending order.
- **Filter Tasks**: Filter tasks based on:
  - Date range (start and end date)
  - Task status (Pending, In Progress, Completed)
  - Specific date conditions (On, Before, After)
  
## Directory Structure

```
Task-Management-System/
│
├── Data/                         # Contains data storage logic
│   ├── DataStorage.cs            # Loads and saves tasks to JSON
│
├── Models/                       # Task-related models
│   ├── Task.cs                   # Task model
│
├── Services/                     # Contains the core logic for task operations
│   ├── FilterService.cs          # Provides filtering functionality
│   ├── TaskService.cs            # Manages tasks (sorting, displaying)
│
├── Utilities/                    # Helper utility classes
│   ├── InputValidator.cs         # Handles user input validation
│
├── bin/                          # Build output folder
│   ├── debug/                    # Debug build files
│   │   ├── net8.0/               # .NET runtime files for target framework
│   │   │   ├── tasks.json        # JSON file storing tasks data
│
├── Program.cs                    # Main entry point of the application
└── README.md                     # This file
```

## tasks.json File

The `tasks.json` file located in the `bin/debug/net8.0/` directory is used to persist the task data. It is in JSON format, which makes it easy to load and save tasks between sessions. Each task contains the following information:

- `TaskID`: Unique identifier for the task.
- `Title`: The title of the task.
- `Description`: A brief description of the task.
- `DueDate`: The due date of the task (in `YYYY-MM-DD` format).
- `Status`: The current status of the task (e.g., "Pending", "In Progress", "Completed").

Example `tasks.json` file:

```json
[
  {
    "TaskID": 1,
    "Title": "Complete Project Report",
    "Description": "Finish writing the final report for the project.",
    "DueDate": "2025-01-20",
    "Status": "Pending"
  },
  {
    "TaskID": 2,
    "Title": "Team Meeting",
    "Description": "Attend the weekly team meeting to discuss progress.",
    "DueDate": "2025-01-15",
    "Status": "Completed"
  }
]
```

## How to Use

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/task-management-system.git
   ```

2. Open the project in Visual Studio or your preferred C# IDE.

3. Build the project to generate the output in the `bin/debug/net8.0/` directory.

4. Run the `Program.cs` file to start interacting with the Task Management System via the console.

5. The system will allow you to:
   - Display existing tasks
   - Add new tasks with title, description, due date, and status
   - Sort tasks based on different criteria
   - Filter tasks by date range or status

6. The task data will be saved in the `tasks.json` file located in `bin/debug/net8.0/`. This ensures that tasks persist across program runs.

## Contributing

If you'd like to contribute to the Task Management System, please fork the repository and submit a pull request with your changes. You can also open issues for bug reports or feature requests.

## License

This project is open source and available under the [MIT License](LICENSE).
