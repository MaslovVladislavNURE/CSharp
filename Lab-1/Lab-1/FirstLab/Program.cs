using EmployeeLibrary.DomainModels;

// Create employee with no data
var emptyEmployee = new Employee();

PrintTaskTitle("1. Empty employee: ");
Console.Write(emptyEmployee.ToString() + "\n\n");

// Create normal employee
var normalEmployee = new Employee("Maslov Vladyslav Sergiyovich", "KIYKI-20-1", Position.Engineer);
PrintTaskTitle("2. Normal employee: ");
Console.WriteLine(normalEmployee.ToString() + "\n");

// Change position and accrual salary
normalEmployee.ChangePosition(Position.Manager);
normalEmployee.AccrualSalary();
PrintTaskTitle("3. Changed position and accrual salary: ");
string str = normalEmployee.ToString();
Console.WriteLine(normalEmployee.ToString() + "\n");

// Change department
normalEmployee.ChangeDepartment("KIYKI-20-6");
PrintTaskTitle("4. Changed department: ");
Console.WriteLine(normalEmployee.ToString() + "\n");

// Find position in history by position: 
string result = normalEmployee.FindPositionInPositionHistory(Position.Engineer);
PrintTaskTitle("5. Find position in history by position Engineer: ");
Console.WriteLine(result + "\n");

// Find position in history by department: 
result = normalEmployee.FindPositionInPositionHistoryByDepartment("KIYKI-20-1");
PrintTaskTitle("6. Find position in history by department KIYKI-20-6: ");
Console.WriteLine(result + "\n");

// Compare two employee by position
var anotherEmployee = new Employee("Ivanenko Vladislav Bogdanovich", "KITKI-20-5", Position.Handyman);
PrintTaskTitle("6. Compare by position (expected: false): ");
Console.WriteLine(normalEmployee.CompareByPosition(anotherEmployee));

anotherEmployee.ChangePosition(Position.Manager);
PrintTaskTitle("7. Compare by position (expected: true): ");
Console.WriteLine(normalEmployee.CompareByPosition(anotherEmployee));

static void PrintTaskTitle(string title)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(title);
    Console.ForegroundColor = ConsoleColor.White;
}