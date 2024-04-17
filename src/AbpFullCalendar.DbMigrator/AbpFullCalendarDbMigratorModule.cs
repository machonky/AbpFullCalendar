using AbpFullCalendar.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpFullCalendar.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpFullCalendarEntityFrameworkCoreModule),
    typeof(AbpFullCalendarApplicationContractsModule)
    )]
public class AbpFullCalendarDbMigratorModule : AbpModule
{
}
