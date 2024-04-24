using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpFullCalendar.BusinessDays;

public interface IBusinessDayAppService : IApplicationService
{
    Task<IList<BusinessDayEventDto>> GetBusinessDaysAsync(DateTime start, DateTime end);
    Task<StoredBusinessDayEventsResultDto> StoreBusinessDaysAsync(SelectedBusinessDayEventsDto selectedBusinessDays);
    Task<MinimumSelectedBusinessDateDto> GetMinSelectableBusinessDateAsync();
}
