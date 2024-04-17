using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpFullCalendar.Data;
using Volo.Abp.DependencyInjection;

namespace AbpFullCalendar.EntityFrameworkCore;

public class EntityFrameworkCoreAbpFullCalendarDbSchemaMigrator
    : IAbpFullCalendarDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpFullCalendarDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AbpFullCalendarDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpFullCalendarDbContext>()
            .Database
            .MigrateAsync();
    }
}
