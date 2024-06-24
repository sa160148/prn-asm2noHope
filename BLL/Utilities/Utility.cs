namespace BLL.Utilities;

public static class Utility
{
    public static int DayNumberCaculator(DateOnly startDate, DateOnly endDate) 
        => (endDate.ToDateTime(new TimeOnly()) - startDate.ToDateTime(new TimeOnly())).Days;

    public static DateOnly CurrentDate() => DateOnly.FromDateTime(DateTime.Now);
}