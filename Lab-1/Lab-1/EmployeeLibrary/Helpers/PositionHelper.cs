namespace EmployeeLibrary.Helpers;

using  EmployeeLibrary.DomainModels;

public static class PositionHelper
{
    public static string ConvertPositionToString(this Position position)
    {
        switch (position)
        {
            case Position.Director:
                return "Director";
            case Position.Engineer:
                return "Engineer";
            case Position.Handyman:
                return "Handyman";
            case Position.Manager:
                return "Manager";
            default:
                return "none";
        }
    }
}