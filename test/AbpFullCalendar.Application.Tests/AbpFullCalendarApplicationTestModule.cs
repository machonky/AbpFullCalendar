using Volo.Abp.Modularity;

namespace AbpFullCalendar;

[DependsOn(
    typeof(AbpFullCalendarApplicationModule),
    typeof(AbpFullCalendarDomainTestModule)
)]
public class AbpFullCalendarApplicationTestModule : AbpModule
{

}
