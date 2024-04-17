using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpFullCalendar.Data;

/* This is used if database provider does't define
 * IAbpFullCalendarDbSchemaMigrator implementation.
 */
public class NullAbpFullCalendarDbSchemaMigrator : IAbpFullCalendarDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
