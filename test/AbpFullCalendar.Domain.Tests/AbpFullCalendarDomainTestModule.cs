using Volo.Abp.Modularity;

namespace AbpFullCalendar;

[DependsOn(
    typeof(AbpFullCalendarDomainModule),
    typeof(AbpFullCalendarTestBaseModule)
)]
public class AbpFullCalendarDomainTestModule : AbpModule
{

}
