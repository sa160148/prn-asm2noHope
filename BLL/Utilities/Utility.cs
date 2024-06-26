namespace BLL.Utilities;

public static class Utility
{
    public static int DayNumberCaculator(DateTime startDate, DateTime endDate) => (endDate - startDate).Days;

    public static DateOnly CurrentDate() => DateOnly.FromDateTime(DateTime.Now);
}