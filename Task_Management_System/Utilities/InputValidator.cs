// Utilities/InputValidator.cs
namespace Task_Management_System.Utilities
{
    public static class InputValidator
    {
        public static DateTime ValidateDateInput(string input)
        {
            if (DateTime.TryParse(input, out DateTime result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid date format. Please use YYYY-MM-DD.");
            }
        }


        public static string ValidateStatusInput(string input)
        {
            string[] validStatuses = { "Pending", "In Progress", "Completed" };
            if (Array.Exists(validStatuses, status => status.Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                return input;
            }

            throw new ArgumentException("Invalid status. Valid options are: Pending, In Progress, Completed.");
        }
    }
}