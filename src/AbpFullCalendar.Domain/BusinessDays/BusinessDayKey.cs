
using MacRobert.StronglyTypeIds;

namespace AbpFullCalendar.BusinessDays;

public record BusinessDayKey(int Value) : IStronglyTypedId<int>;
