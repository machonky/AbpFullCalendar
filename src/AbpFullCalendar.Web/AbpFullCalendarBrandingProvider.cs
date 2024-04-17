using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpFullCalendar.Web;

[Dependency(ReplaceServices = true)]
public class AbpFullCalendarBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpFullCalendar";
}
