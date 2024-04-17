using Volo.Abp.Modularity;

namespace AbpFullCalendar;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpFullCalendarDomainTestBase<TStartupModule> : AbpFullCalendarTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
