using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AbpFullCalendar.BusinessDays;
using Microsoft.Extensions.Logging;
using Volo.Abp.Domain.Repositories;

namespace AbpFullCalendar;

public class BusinessDayAppService : AbpFullCalendarAppService, IBusinessDayAppService
{
    private readonly IRepository<BusinessDay, Guid> businessDayRepository;
    private readonly ILogger<BusinessDayAppService> logger;

    public BusinessDayAppService(IRepository<BusinessDay, Guid> businessDayRepository, ILogger<BusinessDayAppService> logger)
    {
        this.businessDayRepository = businessDayRepository;
        this.logger = logger;
    }

    public async Task<IList<BusinessDayEventDto>> GetBusinessDaysAsync(DateTime start, DateTime end)
    {
        var startKey = start.ToDateKey();
        var endKey = end.ToDateKey();

        IQueryable<BusinessDay> queryable = await businessDayRepository.GetQueryableAsync();
        queryable
            .Where(x => x.BusinessDayId != null &&
                   x.BusinessDayId >= startKey && x.BusinessDayId <= endKey);

        var businessDays = await AsyncExecuter.ToListAsync<BusinessDay>(queryable);

        return businessDays.Select(x => new BusinessDayEventDto
        {
            id = x.BusinessDayId!.Value.ToString(),
            title = "Business Day",
            start = x.BusinessDayId!.FromDateKey().ToString("yyyy-MM-dd")
        }).ToList();
    }

    public Task StoreBusinessDaysAsync(SelectedBusinessDayEventsDto selectedBusinessDays)
    {
        return Task.CompletedTask;
    }
}
