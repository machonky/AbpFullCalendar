
using MacRobert.StronglyTypeIds;
using System;

namespace AbpFullCalendar.BusinessDays;

public record BusinessDayKey(int Value) : IStronglyTypedId<int>
{
    public static bool operator <(BusinessDayKey a, BusinessDayKey b)
    {
        return a.Value < b.Value;
    }

    public static bool operator >(BusinessDayKey a, BusinessDayKey b)
    {
        return a.Value > b.Value;
    }

    public static bool operator <=(BusinessDayKey a, BusinessDayKey b)
    {
        return a < b || a == b;
    }

    public static bool operator >=(BusinessDayKey a, BusinessDayKey b)
    {
        return a > b || a == b;
    }
}

public static class BusinessDayKeyExtensions
{
    public static BusinessDayKey ToDateKey(this DateTime date) => new BusinessDayKey(int.Parse(date.ToString("yyyyMMdd")));
    public static DateOnly FromDateKey(this BusinessDayKey dateIndex) => new DateOnly(year: dateIndex.Value / 10000, month: (dateIndex.Value / 100) % 100, day: dateIndex.Value % 100);
}