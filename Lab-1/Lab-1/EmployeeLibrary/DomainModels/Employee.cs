namespace EmployeeLibrary.DomainModels;

using Helpers;
using System.Linq;
using EmployeeLibrary.Helpers;

public class Employee
{
    /* Fields and properties */
    private string _fullName;
    public string FullName
    {
        get => _fullName;
        set
        {
            ValidateFullNameIfInvalidThrowException(value);
            _fullName = value;
        }
    }

    private int _salary;
    public int Salary
    {
        get => _salary;
    }
    
    private Position _currentPosition;
    public Position CurrentPosition
    {
        get => _currentPosition;
    }
    
    private string[] _positionHistory;

    private string _department;
    public string Department
    {
        get => _department;
    }

    /* Constructors */
    public Employee()
    {
        _fullName = "none";
        _salary = 0;
        _currentPosition = Position.None;
        _department = "none 1";
        
        _positionHistory = new string[0];
    }
    public Employee(string fullName, string department, Position position)
    {
        ValidateFullNameIfInvalidThrowException(fullName);
        _fullName = fullName;
        
        ValidateDepartmentIfInvalidThrowException(department);
        _department = department;
        
        _currentPosition = position;
        _positionHistory = new string[0];
        AddPositionToHistory(position);
        
        AccrualSalary();
    }
    
    /* Business logic */
    public IEnumerable<string> GetPositionHistory()
    {
        foreach (var item in _positionHistory)
        {
            yield return item;
        }
    }

    public void ChangePosition(Position position)
    {
        AddPositionToHistory(position);
        _currentPosition = position;
    }

    private void AddPositionToHistory(Position position)
    {
        _positionHistory = _positionHistory.Concat(new string[] 
                { $"{DateTime.Now}: Position: {position.ConvertPositionToString()}; Department: {_department}" }).ToArray(); 
    }

    public void ChangeDepartment(string department)
    {
        ValidateDepartmentIfInvalidThrowException(department);

        _department = department;
    }

    public int AccrualSalary()
    {
        if (_currentPosition == Position.Director)
            _salary = 50000;
        else if (_currentPosition == Position.Manager)
            _salary = 20000;
        else if (_currentPosition == Position.Engineer)
            _salary = 10000;
        else if (_currentPosition == Position.Handyman)
            _salary = 5000;

        return _salary;
    }

    public string FindPositionInPositionHistory(Position position)
    {
        if (_positionHistory.Length == 0)
            return String.Empty;

        foreach (var item in _positionHistory)
        {
            if (item.Contains(position.ConvertPositionToString()) == true)
                return item;
        }

        return String.Empty;
    }

    public string FindPositionInPositionHistoryByDepartment(string department)
    {
        if (_positionHistory.Length == 0)
            return String.Empty;

        foreach (var item in _positionHistory)
        {
            if (item.Contains(department) == true)
                return item;
        }
        
        return String.Empty;
    }
    
    public bool CompareByPosition(Employee employee)
    {
        if (_currentPosition == employee._currentPosition)
            return true;
        
        return false;
    }

    public override string ToString()
    {
        return $"Name: {_fullName}; Salary: {_salary}; Position: {_currentPosition.ConvertPositionToString()}; " +
               $"Department: {_department};";
    }

    /* Validation methods */
    private static void ValidateFullNameIfInvalidThrowException(string value)
    {
        if (String.IsNullOrEmpty(value) == true || value.Any(char.IsDigit) == true)
        {
            throw new ArgumentException("Full name can not be null or empty and contain numbers");
        }
    }
    private static void ValidateDepartmentIfInvalidThrowException(string department)
    {
        if (department.Any(char.IsDigit) == false || department.Any(char.IsLetter) == false)
        {
            throw new ArgumentException("The position must contain at least one letter and one number");
        }
    }
}