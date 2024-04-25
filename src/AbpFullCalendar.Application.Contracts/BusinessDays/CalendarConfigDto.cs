using System;

namespace AbpFullCalendar.BusinessDays;

public class CalendarConfigDto
{
    public DateTime MinSelectionDate { get; set; }
    public bool UserRoleCanEdit { get; set; }
}