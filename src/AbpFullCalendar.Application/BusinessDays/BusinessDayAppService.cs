using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace AbpFullCalendar.BusinessDays;

public class BusinessDayAppService : AbpFullCalendarAppService, IBusinessDayAppService
{
    private readonly IRepository<BusinessDay, Guid> businessDayRepository;
    private readonly ILogger<BusinessDayAppService> logger;
    private readonly IGuidGenerator guidGenerator;

    public BusinessDayAppService(IRepository<BusinessDay, Guid> businessDayRepository, ILogger<BusinessDayAppService> logger, IGuidGenerator guidGenerator)
    {
        this.businessDayRepository = businessDayRepository;
        this.logger = logger;
        this.guidGenerator = guidGenerator;
    }

    public async Task<IList<BusinessDayEventDto>> GetBusinessDaysAsync(DateTime start, DateTime end)
    {
        var startKey = start.ToDateKey();
        var endKey = end.ToDateKey();

        IQueryable<BusinessDay> queryable = await businessDayRepository.GetQueryableAsync();
        queryable
            .Where(x => (x.BusinessDayId != null) && 
                        (x.BusinessDayId >= startKey) && 
                        (x.BusinessDayId <= endKey));

        var businessDays = await AsyncExecuter.ToListAsync(queryable);

        return businessDays.Select(x => new BusinessDayEventDto
        {
            id = x.BusinessDayId!.Value.ToString(),
            start = x.BusinessDayId!.FromDateKey().ToString("yyyy-MM-dd")
        }).ToList();
    }

    public async Task<StoredBusinessDayEventsResultDto> StoreBusinessDaysAsync([FromBody] SelectedBusinessDayEventsDto selectedBusinessDays)
    {
        var startDate = selectedBusinessDays.StartDate;
        var endDate = selectedBusinessDays.EndDate;

        var selectedDateKeys = Enumerable.Range(0, (endDate - startDate).Days)
            .Select(offset => startDate.AddDays(offset))
            .Select(d => d.ToDateKey()).ToList();

        // We're going to XOR business days. 
        var queryable = await businessDayRepository.GetQueryableAsync();

        // Identify days to remove in bulk...
        var daysToRemove = queryable
            .Where(b => selectedDateKeys.Contains(b.BusinessDayId))
            .ToList();

        // ... and remove them
        await businessDayRepository.DeleteManyAsync(daysToRemove.Select(d => d.Id));

        // Identify days to add in bulk...
        var dateKeysToAdd = selectedDateKeys.Except(daysToRemove.Select(d => d.BusinessDayId)).ToList();
        var newEntities = dateKeysToAdd.Select(d => new BusinessDay(guidGenerator.Create())
        {
            BusinessDayId = d,
            TenantId = CurrentTenant.Id,
        });
        // ... and add them
        await businessDayRepository.InsertManyAsync(newEntities);

        return new StoredBusinessDayEventsResultDto { Success = true };
    }
}
