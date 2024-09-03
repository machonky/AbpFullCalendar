using AbpFullCalendar.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Timing;

namespace AbpFullCalendar.BusinessDays;

public class BusinessDayAppService : AbpFullCalendarAppService, IBusinessDayAppService
{
    private readonly IRepository<BusinessDay, Guid> businessDayRepository;
    private readonly ILogger<BusinessDayAppService> logger;
    private readonly IGuidGenerator guidGenerator;
    private readonly IClock clock;
    private readonly IAuthorizationService authorizationService;

    public BusinessDayAppService(IRepository<BusinessDay, Guid> businessDayRepository, 
                                 ILogger<BusinessDayAppService> logger, 
                                 IGuidGenerator guidGenerator, 
                                 IClock clock,
                                 IAuthorizationService authorizationService)
    {
        this.businessDayRepository = businessDayRepository;
        this.logger = logger;
        this.guidGenerator = guidGenerator;
        this.clock = clock;
        this.authorizationService = authorizationService;
    }

    public async Task<IList<BusinessDayEventDto>> GetBusinessDaysAsync(DateTime start, DateTime end)
    {
        logger.LogInformation($"Getting Business days from {start} to {end}");

        var startKey = start.ToDateKey();
        var endKey = end.ToDateKey();

        var queryable = await businessDayRepository.GetQueryableAsync();
        var businessDays = queryable
            .Where(x => x.BusinessDayId >= startKey && x.BusinessDayId <= endKey)
            .ToList();

        return businessDays.Select(x => new BusinessDayEventDto
        {
            id = x.BusinessDayId.ToString(),
            start = x.BusinessDayId.FromDateKey().ToString("yyyy-MM-dd")
        }).ToList();
    }

    public async Task<CalendarConfigDto> GetCalendarConfigAsync()
    {
        var result = new CalendarConfigDto 
        { 
            MinSelectionDate = clock.Now.ToLocalTime().Date,
            UserRoleCanEdit = await authorizationService.IsGrantedAsync(AbpFullCalendarPermissions.BusinessDays.Edit)
        };

        return result;
    }

    public async Task<StoredBusinessDayEventsResultDto> StoreBusinessDaysAsync([FromBody] SelectedBusinessDayEventsDto selectedBusinessDays)
    {
        var startDate = selectedBusinessDays.StartDate;
        var endDate = selectedBusinessDays.EndDate;

        logger.LogInformation($"Storing Business days from {startDate} to {endDate}");

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
