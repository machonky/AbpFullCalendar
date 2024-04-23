using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace AbpFullCalendar.BusinessDays;

public class BusinessDay : CreationAuditedAggregateRoot<Guid>, IMultiTenant
{
    public BusinessDay(Guid id) : base(id)
    {
    }

    protected BusinessDay() { }

    public virtual BusinessDayKey? BusinessDayId { get; set; }

    public virtual Guid? TenantId { get; set; }
}
