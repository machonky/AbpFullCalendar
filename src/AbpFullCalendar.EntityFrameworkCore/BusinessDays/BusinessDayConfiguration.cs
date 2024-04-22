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
        b.HasAlternateKey(b => new { b.BusinessDayId, b.TenantId });
        b.HasIndex(b => b.TenantId);
    }
}
