using AbpFullCalendar.BusinessDays;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpFullCalendar;

public interface IBusinessDayAppService : IApplicationService
{
    Task<IList<BusinessDayEventDto>> GetBusinessDaysAsync(DateTime start, DateTime end);
    Task StoreBusinessDaysAsync(SelectedBusinessDayEventsDto selectedBusinessDays);
}
