using Microsoft.AspNetCore.Builder;
using AbpFullCalendar;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<AbpFullCalendarWebTestModule>();

public partial class Program
{
}
