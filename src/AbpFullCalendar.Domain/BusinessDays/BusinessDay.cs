using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace AbpFullCalendar.BusinessDays;

public class BusinessDay : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public virtual BusinessDayKey? BusinessDayId { get; set; }

    public virtual Guid? TenantId { get; set; }
}
