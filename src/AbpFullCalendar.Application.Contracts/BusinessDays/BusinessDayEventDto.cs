using System;
using System.Collections.Generic;
using System.Text;

namespace AbpFullCalendar.BusinessDays;

public class BusinessDayEventDto
{
    public string id { get; set; }
    public string title { get; set; }
    public string start { get; set; }
    public bool allDay { get; set; } = true;
}
