using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Humanizer;
using Volo.Abp.MultiTenancy;

namespace AbpFullCalendar.BusinessDays;

public class BusinessDayConfiguration : IEntityTypeConfiguration<BusinessDay>
{
    public void Configure(EntityTypeBuilder<BusinessDay> b)
    {
        b.ToTable(AbpFullCalendarConsts.DbTablePrefix+nameof(BusinessDay).Pluralize(), AbpFullCalendarConsts.DbSchema);
        b.HasKey(b => b.Id);
        b.ConfigureByConvention();
        b.HasIndex(b => new { b.BusinessDayId, b.TenantId }).IsUnique(); // Change from alternetkey to unique key permits the host to store days too since tenantId == null
        b.HasIndex(b => b.TenantId);
    }
}
