var weekDays = new HashSet<DayOfWeek> {
    DayOfWeek.Monday,
    DayOfWeek.Tuesday,
    DayOfWeek.Wednesday,
    DayOfWeek.Thursday,
    DayOfWeek.Friday,
};

DateOnly startDate = new DateOnly(year: 2024, month: 07, day: 01);
DateOnly endDate = new DateOnly(year: 2024, month: 08, day: 30);
for (DateOnly date = startDate; date <= endDate; date = date.AddDays(1))
{
    if (weekDays.Contains(date.DayOfWeek))
    {
        int dateIndex = date.Year * 10000 + date.Month * 100 + date.Day;
        var tenantId = "3a121785-82d6-878e-970b-6b6b71e9a3e0";
        var tenant1Id = "3a121850-e6d8-2449-c862-b652496fa4a1";
        var statement = $$"""
INSERT INTO public."AppBusinessDays" ("Id", "BusinessDayId", "TenantId", "ExtraProperties", "ConcurrencyStamp", "CreationTime", "CreatorId", "LastModificationTime", "LastModifierId", "IsDeleted", "DeleterId", "DeletionTime")
VALUES('{{Guid.NewGuid().ToString()}}'::uuid, {{dateIndex}}, '{{tenant1Id}}'::uuid, '', '{{Guid.NewGuid().ToString("N")}}', '{{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}}', NULL, NULL, NULL, false, NULL, NULL);
""";
        Console.WriteLine(statement);
    }
}
 