
using MacRobert.StronglyTypeIds;
using System;
using System.Collections.Generic;

namespace AbpFullCalendar.BusinessDays;

public record BusinessDayKey(int Value) : IStronglyTypedId<int>, IComparable<BusinessDayKey>
{
    public static bool operator <(BusinessDayKey a, BusinessDayKey b)
    {
        if (a == null) return b != null;  // Null is less than any non-null
        if (b == null) return false;      // No non-null is less than null
        return a.CompareTo(b) < 0;
    }

    public static bool operator >(BusinessDayKey a, BusinessDayKey b)
    {
        if (a == null) return false;  // Null is not greater than anything
        if (b == null) return true;   // Anything is greater than null
        return a.CompareTo(b) > 0;
    }

    public static bool operator >=(BusinessDayKey a, BusinessDayKey b)
    {
        return !(a < b);
    }

    public static bool operator <=(BusinessDayKey a, BusinessDayKey b)
    {
        return !(a > b);
    }

    public int CompareTo(BusinessDayKey? other)
    {
        if (other == null) return 1;  // Consider non-null > null
        return Value.CompareTo(other.Value);
    }
}

public static class BusinessDayKeyExtensions
{
    public static BusinessDayKey ToDateKey(this DateTime date) => new BusinessDayKey(int.Parse(date.ToString("yyyyMMdd")));
    public static DateOnly FromDateKey(this BusinessDayKey dateIndex) => new DateOnly(year: dateIndex.Value / 10000, month: (dateIndex.Value / 100) % 100, day: dateIndex.Value % 100);
}