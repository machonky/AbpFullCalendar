using System.Threading.Tasks;

namespace AbpFullCalendar.Data;

public interface IAbpFullCalendarDbSchemaMigrator
{
    Task MigrateAsync();
}
